namespace QuoteRatingApi.QuoteRatingEngine.Premium
{
    /// <summary>
    /// Responsible for calculating premium for quote
    /// </summary>
    public interface IPremiumQuoteCalculator
    {
        /// <summary>
        /// Calculates the premium quote
        /// </summary>
        decimal CalculatePremiumQuote(decimal revenue, decimal stateFactor, decimal businessFactor, decimal basePremiumDivisor, int hazardFactor);
    }
}
