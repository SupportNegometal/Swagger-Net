﻿using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;

namespace Swashbuckle.Tests.CoreUnitTests
{
    [TestFixture]
    class SchemaExtensionsTests
    {
        Schema schema
        {
            get
            {
                var schemaRegistry =  new SchemaRegistry(
                    new JsonSerializerSettings(),
                    new Dictionary<Type, Func<Schema>>(),
                    new List<ISchemaFilter>(),
                    new List<IModelFilter>(),
                    true, null, true, true, true);
                return schemaRegistry.CreateInlineSchema(typeof(object));
            }
        }

        [Test]
        public void WithValidationProperties_Null()
        {
            var mock = new Mock<JsonProperty>();
            Assert.IsNotNull(schema.WithValidationProperties(mock.Object));
        }

        [Test]
        public void PopulateFrom_Null()
        {
            var partSchema = new PartialSchema();
            Schema nullSchema = null;
            Assert.DoesNotThrow(() => partSchema.PopulateFrom(nullSchema));
        }
    }
}