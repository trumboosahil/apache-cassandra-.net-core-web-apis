"# cassandra-.net-core-web-apis" 


In cassandra we can store list,set, dictionary

In our data one driver in one task as multiple shipments

| DriverId | TaskId | OrderIDs |
| ----      | ----        | ------- |
| 23      | 1        | 21,23,24,527 |
| 23      | 2        | 22,45,67,89|
| 24      | 3        | 78,998,887 |
| 25      | 4        |123,44,567,98 |

In cassandra create secondary index on OrderIDs

Select * from OrderIDs CONTAINS 21
