using System;
using Newtonsoft.Json;

namespace hacka_getnet.Entidades.GetNet
{

        public partial class Payment
        {
            [JsonProperty("seller_id")]
            public Guid SellerId { get; set; }

            [JsonProperty("amount")]
            public decimal Amount { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("order")]
            public Order Order { get; set; }

            [JsonProperty("customer")]
            public Customer Customer { get; set; }

            [JsonProperty("credit")]
            public Credit Credit { get; set; }
        }


        public partial class Credit
        {
            [JsonProperty("delayed")]
            public bool Delayed { get; set; }

            [JsonProperty("authenticated")]
            public bool Authenticated { get; set; }

            [JsonProperty("pre_authorization")]
            public bool PreAuthorization { get; set; }

            [JsonProperty("save_card_data")]
            public bool SaveCardData { get; set; }

            [JsonProperty("transaction_type")]
            public string TransactionType { get; set; }

            [JsonProperty("number_installments")]
            public long NumberInstallments { get; set; }

            [JsonProperty("soft_descriptor")]
            public string SoftDescriptor { get; set; }

            [JsonProperty("dynamic_mcc")]
            public long DynamicMcc { get; set; }

            [JsonProperty("card")]
            public Card Card { get; set; }
        }

        public partial class Card
        {
            [JsonProperty("number_token")]
            public string NumberToken { get; set; }

            [JsonProperty("cardholder_name")]
            public string CardholderName { get; set; }

            [JsonProperty("security_code")]
            public string SecurityCode { get; set; }

            [JsonProperty("brand")]
            public string Brand { get; set; }

            [JsonProperty("expiration_month")]
            public string ExpirationMonth { get; set; }

            [JsonProperty("expiration_year")]
            public string ExpirationYear { get; set; }
        }

        public partial class Customer
        {
            [JsonProperty("customer_id")]
            public string CustomerId { get; set; }

            [JsonProperty("first_name")]
            public string FirstName { get; set; }

            [JsonProperty("last_name")]
            public string LastName { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("document_type")]
            public string DocumentType { get; set; }

            [JsonProperty("document_number")]
            public string DocumentNumber { get; set; }

            [JsonProperty("phone_number")]
            public string PhoneNumber { get; set; }

            [JsonProperty("billing_address")]
            public BillingAddress BillingAddress { get; set; }
        }

        public partial class BillingAddress
        {
            [JsonProperty("street")]
            public string Street { get; set; }

            [JsonProperty("number")]
            public string Number { get; set; }

            [JsonProperty("complement")]
            public string Complement { get; set; }

            [JsonProperty("district")]
            public string District { get; set; }

            [JsonProperty("city")]
            public string City { get; set; }

            [JsonProperty("state")]
            public string State { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("postal_code")]
            public string PostalCode { get; set; }
        }

        public partial class Order
        {
            [JsonProperty("order_id")]
            public Guid OrderId { get; set; }

            [JsonProperty("sales_tax")]
            public long SalesTax { get; set; }

            [JsonProperty("product_type")]
            public string ProductType { get; set; }
        }
    

}
