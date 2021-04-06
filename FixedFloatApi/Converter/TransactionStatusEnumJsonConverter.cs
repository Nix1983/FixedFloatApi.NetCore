using FixedFloatApi.Enums;
using Newtonsoft.Json;
using System;

namespace FixedFloatApi.Converter
{
    public class TransactionStatusEnumJsonConverter : JsonConverter
    {

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            // Handle only boolean types.
            return objectType == typeof(ExchangeStatus);
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>
        /// The object value.
        /// </returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.Value.ToString().ToLower())
            {
                case "0":
                    return ExchangeStatus.New;
                case "1":
                    return ExchangeStatus.Waiting;
                case "2":
                    return ExchangeStatus.CurrencyExchange;
                case "3":
                    return ExchangeStatus.SendingFunds;
                case "4":
                    return ExchangeStatus.OrderCompleted;
                case "5":
                    return ExchangeStatus.OrderExpired;
                case "6":
                    return ExchangeStatus.NotInUse;
                case "7":
                    return ExchangeStatus.DecisionMustMade;
            }

            // If we reach here, we're pretty much going to throw an error so let's let Json.NET throw it's pretty-field error message.
            throw new JsonSerializationException();
        }

        /// <summary>
        /// Specifies that this converter will not participate in writing results.
        /// </summary>
        public override bool CanWrite { get { return false; } }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter"/> to write to.</param><param name="value">The value.</param><param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
        }

    }
}
