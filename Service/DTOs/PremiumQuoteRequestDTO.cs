using QuoteRatingApi.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace QuoteRatingApi.Service.DTOs
{
    /// <summary>
    /// Request DTO for premium quote
    /// </summary>
    public sealed class PremiumQuoteRequestDTO
    {
        /// <summary>
        /// Revenue used for premium quote
        /// </summary>
        /// <remarks>
        /// Range attribute does not accept decimals as arguments
        /// </remarks>
        [Range(double.MinValue, double.MaxValue)]
        public decimal Revenue { get; set; }

        /// <summary>
        /// State Code used for premium quote
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StatePostalCode State { get; set; }

        /// <summary>
        /// Business Type used for premium quote
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BusinessType Business { get; set; }
    }
}
