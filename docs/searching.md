# Searching

1. Text search in elasticsearch is implemented differently for the different string types, [keyword](https://www.elastic.co/guide/en/elasticsearch/reference/current/keyword.html) and [text](https://www.elastic.co/guide/en/elasticsearch/reference/current/text.html), as explained [here](https://www.elastic.co/blog/strings-are-dead-long-live-strings). With Azure Data Explorer, there is a single string type, and text searches are applied in a way that correlates to searching on an elasticsearch text data type. Some use cases which show the difference in search behavior include:

    * Search which was applied using a value expected to be found on an elasticseach keyword data type, will yield more results on Azure Data Explorer.

    * A case sensitive search which was applied using a value expected to be found on an elasticseach keyword data type, will yield non case sensitive results on Azure Data Explorer.

2. Multiple words in a search term are split based on operators and analyzed individually, combined with an OR operator in both elsticsearch and Azure Data Explorer.

    TODO: under development to support searching multiple words individually [here](https://dev.azure.com/csedevil/K2-bridge-internal/_workitems/edit/1579).

3. When enclosing strings with quotation marks, the exact quoted term is being searched in both elsticsearch and Azure Data Explorer.

    TODO: under development to support searching exact terms [here](https://dev.azure.com/csedevil/K2-bridge-internal/_workitems/edit/1609).

4. Partial support for Azure Data Explorer's `dynamic column` - those columns represent objects with an unknown schema. Those columns are visible in the item view as "flat" properties. However, their 1-click search icons (the +/-) are disabled. Additionally, those columns won't appear in the add filter option.

    TODO: update if/when we add support for dynamic columns. https://dev.azure.com/csedevil/K2-bridge-internal/_workitems/edit/1253

    Options for better interaction with dynamic columns:
        * Use Lucene expressions in the search box with a fully qualified property path. For example: propertyA.propertyB:myValue
        * If possible, consider promoting some/all properties in a dynamic column to regular-discreet columns in Azure Data Explorer. By doing so, you'll also get a potential performance boost when searching.