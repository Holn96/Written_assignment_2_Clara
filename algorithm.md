>##### CALL processCSV
                              
---
>####   FUNCTION processCSV 
>>#####     FETCH the CSV file 
>>#####     CONVERT the response to text 
>>#####     SET PARSEDTEXT = PARSE the CSV text using PapaParse
>>#####     SET AggregatedData = CALL aggregatedData (PARSEDTEXT)
>>#####     Return  AggregatedData
---
>####   Function aggregateData(data):
>>####    SET groupedData to empty dictionary
>>####    For row=0 To data.length:
>>>####        SET bookName to row.BookName
>>>####        SET OrderStatus to row.OrderStatus
>>>####        If (bookName is not in groupedData):
>>>>#####           Set groupedData[bookName] to 0
>>>####        EndIf
>>>####        If (OrderStatus is 'Returned'):
>>>>#####            Increment groupedData[bookName] by 1
>>>####        EndIf
>>####    EndFor
>>####    Return groupedData
---
>#### FUNCTION generateTable(data):
>>#### For book=0 in data:
>>>####     Add book row into tableBody
>>>####     Add cell with book name
>>>####     Add cell with book total
>>#### EndFor