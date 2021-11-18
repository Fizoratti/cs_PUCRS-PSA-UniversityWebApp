
#### Fluent API - Configuring and Mapping Properties and Types

##### Configuring a Composite Primary Key

The following example configures the DepartmentID and Name properties to be the composite primary key of the Department type.

```
modelBuilder.Entity<Department>().HasKey(t => new { t.DepartmentID, t.Name });
```

