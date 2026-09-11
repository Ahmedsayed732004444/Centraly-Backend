namespace Centraly.Api.Contracts.Inventory.Products;

/// <summary>
/// ØªØµØ­ÙŠØ­ ÙŠØ¯ÙˆÙŠ Ù„ÙƒÙ…ÙŠØ© Ø§Ù„Ù…Ø®Ø²ÙˆÙ† (Ø¬Ø±Ø¯ Ù Ø¹Ù„ÙŠ) Ù„Ø¯Ù Ø¹Ø© Ù…Ø­Ø¯Ø¯Ø©
/// </summary>
public record AdjustProductQuantityRequest(
    string  BatchId,
    int     NewQuantity,
    string? Reason
);