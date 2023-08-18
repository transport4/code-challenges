
'Question #1: What is this function doing?  Rename it to give an indicator of its functionality.
Public Function Foo (table As DataTable, ByVal columnName As String) As String

    If (table Is Nothing) Then
        Return String.Empty
    End If

    Dim sb As New StringBuilder()
    Dim d As String = String.Empty

    For Each row As DataRow In table.Rows
        sb.AppendFormat("{0}{1}", d, row(columnName).ToString())
        If (String.IsNullOrEmpty(d)) Then
            d = ","
        End If
    Next

    Return sb.ToString()

End Function

'Question #2: Describe what this function does.  Do you see the bug in this code?
Public Overloads Function AddMultipleSpecies(ByRef ds() As System.Data.DataSet, ByVal user As String, 
                                      ByVal dsActionOnSuccess As IPlanets.DataSetActionOnSuccess, 
                                      ByVal issueWarningErrors As Boolean, 
                                      ByRef transactionID As Integer) As IPlanets.ActionResponseType Implements IPlanets.AddSpecies

        Dim returnFlag As Boolean = False
        Dim transactionResponse As IPlanets.ActionResponseType = IPlanets.ActionResponseType.ErrorsExist
        Dim iCount As Integer = 1
        Try

            Using tranScope As System.Transactions.TransactionScope = Tran.BeginTransaction(Tran.TranType.Required)

                For Each dsSpecies As DataSet In ds
                    If returnFlag = True Or iCount = 1 Then
                        transactionResponse = AddSpecies(dsSpecies, user, dsActionOnSuccess, issueWarningErrors, transactionID)

                        If transactionResponse = IPlanets.ActionResponseType.Success Then
                            returnFlag = True
                        Else
                            returnFlag = False
                        End If
                    End If
                    iCount = 1
                Next
                If returnFlag Then
                    tranScope.Complete()

                End If

            End Using

        Catch ex As Exception
            ErrorHandler.ErrorProcess(ex, Me.GetType.ToString, "AddMultipleSpecies", user)
        End Try

        Return transactionResponse

    End Function

'Question #3: What does this function do?  Where would you speculate you'd need to look next to figure out why the Wookie's aren't 
'getting the return type they're expecting?
Private Sub planetSearchGrid_SubmitData(sender As Object, e As SubmitDataEventArgs) Handles planetSearchGrid.SubmitData
    Dim dsResult As DataSet
    Dim dt As DataTable
    Dim columnList As String = HiddenFieldSelectedGridColumns.Value
    Dim columnHeaderList As String = HiddenFieldSelectedGridColumnsHeaders.Value

    Try
        Dim xml As XmlNode = e.Xml

        Select Case FormatType.Value.ToString.ToUpper
            Case "Galactic Basic"
                ExportToGalacticBasic(xml)
            Case "Shyriiwook"

                Dim crit As New SearchCriteria

                dt = dtCriteriaCache
                
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    dt.Rows(0)("page_return_type_id") = 102
                Else
                    dt.Rows(0)("page_return_type_id") = 103
                End If
                
                ReturnShyriiwookFile(dsResult.Tables(0), crit.BuildCriteriaDef(dtCriteriaCache.DataSet, True), columnHeaderList, columnList)
        
        End Select
    
    Catch ex As Exception
        ErrorHandler.ErrorProcess(ex, Me.GetType().ToString, System.Reflection.MethodInfo.GetCurrentMethod.Name, user)
    Finally
        If Not dt Is Nothing Then
            dt.Dispose()
            dt = Nothing
        End If
    End Try

End Sub