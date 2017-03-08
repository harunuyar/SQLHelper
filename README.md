# SQLHelper

A little SQL library to simplify database operations.

Opening Connection
```sh
SQLDatabase db = new SQLDatabase("connectionString");
```

Inserting
```sh
SQLEntry entry = new SQLEntry();
entry.add("column1", "value1");
// OR entry.add(new SQLItem("column1", "value1"));
SQLQuery query = new SQLQuery("tableName", entry, null);
db.insert(query);
```

Updating
```sh
SQLEntry updateTheseColumns = new SQLEntry();
updateTheseColumns.add("column1", "value1");
SQLEntry updateConditions = new SQLEntry();
updateConditions.add("column2", "value2", SQLItem.EQUAL);
updateConditions.add("column3", "value3", SQLItem.GREATER);
SQLQuery query = new SQLQuery("tableName", updateTheseColumns, updateConditions);
db.update(query);
```

Deleting
```sh
SQLEntry deleteConditions = new SQLEntry();
deleteConditions.add("column2", "value2", SQLItem.NOT_EQUAL);
SQLQuery query = new SQLQuery("tableName", null, deleteConditions);
db.update(query);
```

Selecting
```sh
SQLEntry selectConditions = new SQLEntry();
selectConditions.add("column2", "value2", SQLItem.EQUAL);
SQLEntry selectColumns = new SQLEntry();
selectColumns.add("column1", null);
selectColumns.add("column3", null);
SQLQuery query = new SQLQuery("tableName", selectColumns, selectConditions);
SQLResult result = db.select(query);
while (result.hasNext())
{
  SQLEntry en = result.next();
  for (int i=0; i<en.getCount(); i++)
    en.getValue(i);
}
```

