# CAMLBuilder
Small and simple API which allows you to easily write CAML queries, in a declarative way.

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

[![Build Status](https://travis-ci.org/joaope/CAMLBuilder.svg?branch=master)](https://travis-ci.org/joaope/CAMLBuilder) [![Analytics](https://ga-beacon.appspot.com/UA-55655362-2/joaope/camlbuilder/readme.md)](https://github.com/joaope/camlbuilder)
