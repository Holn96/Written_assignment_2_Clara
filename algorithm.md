>##### CALL processCSV
                              
---
>####   FUNCTION processCSV 
>>#####     FETCH the CSV file 
>>#####     CONVERT the response to text 
>>#####     SET PARSEDTEXT to PARSE the CSV text using PapaParse
>>#####     SET AggregatedData to CALL aggregatedData (PARSEDTEXT)
>>#####     Return  AggregatedData
---
>####   Function aggregateData(data):
>>####    SET groupedData to empty dictionary
>>####    SET row to 0
>>####    WHILE row < LEN(data):
>>>####        SET bookName to row.BookName
>>>####        SET OrderStatus to row.OrderStatus
>>>####        If (bookName is not in groupedData):
>>>>#####           Set groupedData[bookName] to 0
>>>####        EndIf
>>>####        If (OrderStatus is 'Returned'):
>>>>#####            SET groupedData[bookName] to groupedData[bookName]+1
>>>####        EndIf
>>>####        set row to row + 1
>>####    Return groupedData
---
>#### FUNCTION generateTable(data):
>>#### SET book to 0
>>#### WHILE book < LEN(data):
>>>####     Add book row into tableBody
>>>####     Add cell with book name
>>>####     Add cell with book total
>>>####     SET book to book + 1