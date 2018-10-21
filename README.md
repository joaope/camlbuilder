# CAMLBuilder
Small and simple API which allows you to easily write CAML queries, in a declarative way.

[![Build status](https://ci.appveyor.com/api/projects/status/1a5mcdp2ysrjor42/branch/master?svg=true)](https://ci.appveyor.com/project/joaope/camlbuilder/branch/master)
[![NuGet](https://img.shields.io/nuget/v/CamlBuilder.svg?maxAge=2592000)](https://www.nuget.org/packages/CamlBuilder)

## Example:

```C#
var and = 
    LogicalJoin.And(
        Operator.Contains("HairColors", ValueType.Text, "brown"),
        Operator.BeginsWith("Name", ValueType.Text, "John"),
        Operator.GreaterThanOrEqualTo("Age", ValueType.Integer, 21),
        LogicalJoin.Or(
            Operator.IsNotNull("Counter"),
            Operator.IsNull("Flag")));

var queryCaml = 
    Query.Build(and)
        .OrderBy("Country")
        .OrderBy(new FieldReference("Age") { Ascending = false })
        .GroupBy("Address")
        .GetCaml();

// or the strongly-typed equivalent

var and =
    LogicalJoin.And(
        Operator.Contains<MyClass, string>(m => m.HairColors, ValueType.Text, "brown"),
        Operator.BeginsWith<MyClass, string>(m => m.Name, ValueType.Text, "John"),
        Operator.GreaterThanOrEqualTo<MyClass, int>(m => m.Age, ValueType.Integer, 21),
        LogicalJoin.Or(
            Operator.IsNotNull<MyClass, double>(m => m.Counter),
            Operator.IsNull<MyClass, bool>(m => m.Flag)));

var queryCaml =
    Query.Build(and)
        .OrderBy<MyClass, string>(m => m.Country)
        .OrderBy(new FieldReference<MyClass, int>(m => m.Age) { Ascending = false })
        .GroupBy<MyClass, string>(m => m.Address)
        .GetCaml();

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
   </Where>
   <GroupBy>
      <FieldRef Name='Address' />
   </GroupBy>
   <OrderBy>
      <FieldRef Name='Country' />
      <FieldRef Name='Age' Ascending='False' />
   </OrderBy>
</Query>
```