using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FoodManager.Infrastructure.Constants;
using FoodManager.Infrastructure.Enums;
using FoodManager.Infrastructure.Extensions;
using FoodManager.Infrastructure.Resolvers;

namespace FoodManager.Infrastructure.Exports
{
    public class CsvExport
    {
        private string _excelString = "";

        #region Retrieve

        public Stream RetrieveFile()
        {
            var bytes = Encoding.Unicode.GetBytes(_excelString);
            var stream = new MemoryStream(bytes);
            return stream;
        }

        public Stream RetrieveError()
        {
            _excelString = String.Empty;
            ConcatRow(0, MessageConstants.ExportWithErrors);
            return RetrieveFile();
        }

        #endregion

        #region Concat

        public void ConcatRows<T>(int spaceNumber, string propertiesCommaSeparated, IEnumerable<T> objects)
        {
            foreach (var objectRetrieved in objects)
                ConcatRow(spaceNumber, propertiesCommaSeparated, objectRetrieved);
        }

        public void ConcatRow<T>(int spaceNumber, string propertiesCommaSeparated, T objectRetrieved)
        {
            var row = string.Empty;
            var propertiesToRetrieve = propertiesCommaSeparated.Split(',').ToList();
            propertiesToRetrieve.ForEach(property =>
            {
                var value = ExtractValue(property, objectRetrieved);
                var comma = row.IsNullOrEmpty() ? string.Empty : ",";
                row += string.Concat(comma, value);
            });

            ConcatRow(spaceNumber, row);
        }

        public void ConcatRow(int spaceNumber, string row)
        {
            var commans = string.Concat(Enumerable.Repeat(",", spaceNumber));
            row = string.Concat(commans, row, "\n");
            _excelString = string.Concat(_excelString, row);
        }

        #endregion

        #region Private Methods

        private static string ExtractValue<T>(string property, T objectRetrieved)
        {
            property = property.Trim();
            var valueRetrieved = objectRetrieved.ExtractProperty(property);
            var valueString = String.Empty;

            if (valueRetrieved.IsNotNull())
            {
                switch (property)
                {
                    case "Region":
                    case "Company":
                    case "Branch":
                    case "Disease":
                    case "IngredientGroup":
                    case "Dealer":
                    case "Department":
                    case "Job":
                    case "Saucer":
                    case "Role":
                        valueString = valueRetrieved.ExtractName();
                        break;
                    case "Protein":
                    case "Carbohydrate":
                    case "Sugar":
                    case "Lipid":
                    case "Sodium":
                    case "NetWeight":
                        valueString = String.Format("{0}{1}", valueRetrieved, DisplayConstants.Gram);
                        break;
                    case "Badge":
                    case "Code":
                    case "Imss":
                        valueString = String.Format(" [{0}] ", valueRetrieved);
                        break;
                    case "Saucers":
                    case "Dealers":
                        valueString = valueRetrieved.ExtractNames();
                        break;
                    case "Energy":
                    case "LimitEnergy":
                        valueString = String.Format("{0} {1}", valueRetrieved, DisplayConstants.KiloCalorie);
                        break;
                    case "Status":
                        valueString = EnumResolver.Status(Convert.ToBoolean(valueRetrieved));
                        break;
                    case "Gender":
                        valueString = EnumResolver.Gender(GenderType.Male.GetValue());
                        break;
                    case "SaucerConfigurations":
                        valueString = valueRetrieved.ExtractTotalAmounts();
                        break;
                    case "SaucerMultimedias":
                        valueString = valueRetrieved.ExtractPaths();
                        break;
                    default:
                        valueString = valueRetrieved.ToString();
                        break;
                }
            }

            return valueString.Replace(",", " ");
        }

        #endregion
    }
}