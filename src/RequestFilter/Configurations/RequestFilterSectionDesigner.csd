<?xml version="1.0" encoding="utf-8"?>
<configurationSectionModel xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="295c771f-ca2a-4954-90b0-315830ef7218" namespace="RequestFilter.Configurations" xmlSchemaNamespace="urn:RequestFilter.Configurations" assemblyName="RequestFilter.Configurations" xmlns="http://schemas.microsoft.com/dsltools/ConfigurationSectionDesigner">
  <typeDefinitions>
    <externalType name="String" namespace="System" />
    <externalType name="Boolean" namespace="System" />
    <externalType name="Int32" namespace="System" />
    <externalType name="Int64" namespace="System" />
    <externalType name="Single" namespace="System" />
    <externalType name="Double" namespace="System" />
    <externalType name="DateTime" namespace="System" />
    <externalType name="TimeSpan" namespace="System" />
    <externalType name="Type" namespace="System" />
    <externalType name="CommaDelimitedStringCollection" namespace="System.Configuration" />
  </typeDefinitions>
  <configurationElements>
    <configurationSection name="RequestFilterSection" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="requestFilter">
      <elementProperties>
        <elementProperty name="Filters" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="filters" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/295c771f-ca2a-4954-90b0-315830ef7218/Filters" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElementCollection name="Filters" collectionType="AddRemoveClearMap" xmlItemName="filter" codeGenOptions="AddMethod, RemoveMethod">
      <itemType>
        <configurationElementMoniker name="/295c771f-ca2a-4954-90b0-315830ef7218/Filter" />
      </itemType>
    </configurationElementCollection>
    <configurationElement name="Filter">
      <attributeProperties>
        <attributeProperty name="Type" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="type" isReadOnly="false" typeConverter="TypeNameConverter">
          <type>
            <externalTypeMoniker name="/295c771f-ca2a-4954-90b0-315830ef7218/Type" />
          </type>
        </attributeProperty>
        <attributeProperty name="Index" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="index" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/295c771f-ca2a-4954-90b0-315830ef7218/Int32" />
          </type>
        </attributeProperty>
        <attributeProperty name="Key" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="key" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/295c771f-ca2a-4954-90b0-315830ef7218/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="Params" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="params" isReadOnly="false" typeConverter="CommaDelimitedStringCollectionConverter">
          <type>
            <externalTypeMoniker name="/295c771f-ca2a-4954-90b0-315830ef7218/CommaDelimitedStringCollection" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
  </configurationElements>
  <propertyValidators>
    <validators />
  </propertyValidators>
</configurationSectionModel>