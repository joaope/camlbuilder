# CAMLBuilder
Small and simple API which allows you to easily write CAML queries, in a declarative way.

[![Build status](https://ci.appveyor.com/api/projects/status/1a5mcdp2ysrjor42/branch/master?svg=true)](https://ci.appveyor.com/project/joaope/camlbuilder/branch/dnx)

## Example:

```C#
var and = 
    CamlLogicalJoin.And(
        CamlOperator.Contains("HairColors", CamlFieldType.Text, "brown"),
        CamlOperator.BeginsWith("Name", CamlFieldType.Text, "John"),
        CamlOperator.GreaterThanOrEqualTo("Age", CamlFieldType.Integer, 21),
        CamlLogicalJoin.Or(
            CamlOperator.IsNotNull("Counter"),
            CamlOperator.IsNull("Flag")));

var queryCaml = 
    CamlQuery.BuildQuery(and)
        .OrderBy("Country", CamlOrderByFieldOrder.Ascending)
        .OrderBy("Age", CamlOrderByFieldOrder.Descending)
        .GroupBy("Address")
        .GetQueryClause();
```

## Output:

```XML
<Query>
   <Where>
      <And>
         <Contains>
            <FieldRef Name='HairColors' />
            <Value Type='Text'>brown</Value>
         </Contains>
         <And>
            <BeginsWith>
               <FieldRef Name='Name' />
               <Value Type='Text'>John</Value>
            </BeginsWith>
            <And>
               <Geq>
                  <FieldRef Name='Age' />
                  <Value Type='Integer'>21</Value>
               </Geq>
               <Or>
                  <IsNotNull>
                     <FieldRef Name='Counter' />
                  </IsNotNull>
                  <IsNull>
                     <FieldRef Name='Flag' />
                  </IsNull>
               </Or>
            </And>
         </And>
      </And>
      <GroupBy>
         <FieldRef Name='Address' />
      </GroupBy>
      <OrderBy>
         <FieldRef Name='Country' />
         <FieldRef Name='Age' Ascending='False' />
      </OrderBy>
   </Where>
</Query>
```

[![Analytics](https://ga-beacon.appspot.com/UA-55655362-2/joaope/camlbuilder/readme.md)](https://github.com/joaope/camlbuilder)
