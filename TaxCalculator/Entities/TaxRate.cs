using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaxSerices.Entities
{
    public class RateResponse
    {
        [JsonProperty("rate")]
        public RateResponseAttributes Rate { get; set; }
    }

    public class RateResponseAttributes
    {
        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("state_rate")]
        public decimal StateRate { get; set; }

        [JsonProperty("county")]
        public string County { get; set; }

        [JsonProperty("county_rate")]
        public decimal CountyRate { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("city_rate")]
        public decimal CityRate { get; set; }

        [JsonProperty("combined_district_rate")]
        public decimal CombinedDistrictRate { get; set; }

        [JsonProperty("combined_rate")]
        public decimal CombinedRate { get; set; }

        [JsonProperty("freight_taxable")]
        public bool FreightTaxable { get; set; }

        // International
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        // Australia / SST States
        [JsonProperty("country_rate")]
        public decimal CountryRate { get; set; }

        // European Union
        [JsonProperty("standard_rate")]
        public decimal StandardRate { get; set; }

        [JsonProperty("reduced_rate", NullValueHandling = NullValueHandling.Ignore)]
        public decimal ReducedRate { get; set; }

        [JsonProperty("super_reduced_rate", NullValueHandling = NullValueHandling.Ignore)]
        public decimal SuperReducedRate { get; set; }

        [JsonProperty("parking_rate", NullValueHandling = NullValueHandling.Ignore)]
        public decimal ParkingRate { get; set; }

        [JsonProperty("distance_sale_threshold", NullValueHandling = NullValueHandling.Ignore)]
        public decimal DistanceSaleThreshold { get; set; }
    }

    public class Rate
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }
    }

    public class TaxResponse
    {
        [JsonProperty("tax")]
        public TaxResponseAttributes Tax { get; set; }
    }

    public class TaxResponseAttributes
    {
        [JsonProperty("order_total_amount")]
        public decimal OrderTotalAmount { get; set; }

        [JsonProperty("shipping")]
        public decimal Shipping { get; set; }

        [JsonProperty("taxable_amount")]
        public decimal TaxableAmount { get; set; }

        [JsonProperty("amount_to_collect")]
        public decimal AmountToCollect { get; set; }

        [JsonProperty("rate")]
        public decimal Rate { get; set; }

        [JsonProperty("has_nexus")]
        public bool HasNexus { get; set; }

        [JsonProperty("freight_taxable")]
        public bool FreightTaxable { get; set; }

        [JsonProperty("tax_source")]
        public string TaxSource { get; set; }

        [JsonProperty("exemption_type")]
        public string ExemptionType { get; set; }

        [JsonProperty("jurisdictions")]
        public TaxJurisdictions Jurisdictions { get; set; }

        [JsonProperty("breakdown")]
        public TaxBreakdown Breakdown { get; set; }
    }
    public class Breakdown
    {
        [JsonProperty("taxable_amount")]
        public decimal TaxableAmount { get; set; }

        [JsonProperty("tax_collectable")]
        public decimal TaxCollectable { get; set; }

        [JsonProperty("combined_tax_rate")]
        public decimal CombinedTaxRate { get; set; }

        [JsonProperty("state_taxable_amount")]
        public decimal StateTaxableAmount { get; set; }

        [JsonProperty("county_taxable_amount")]
        public decimal CountyTaxableAmount { get; set; }

        [JsonProperty("county_tax_rate")]
        public decimal CountyTaxRate { get; set; }

        [JsonProperty("city_taxable_amount")]
        public decimal CityTaxableAmount { get; set; }

        [JsonProperty("city_tax_rate")]
        public decimal CityTaxRate { get; set; }

        // International
        [JsonProperty("country_taxable_amount")]
        public decimal CountryTaxableAmount { get; set; }

        [JsonProperty("country_tax_rate")]
        public decimal CountryTaxRate { get; set; }

        [JsonProperty("country_tax_collectable")]
        public decimal CountryTaxCollectable { get; set; }

        // Canada
        [JsonProperty("gst_taxable_amount")]
        public decimal GSTTaxableAmount { get; set; }

        [JsonProperty("gst_tax_rate")]
        public decimal GSTTaxRate { get; set; }

        [JsonProperty("gst")]
        public decimal GST { get; set; }

        [JsonProperty("pst_taxable_amount")]
        public decimal PSTTaxableAmount { get; set; }

        [JsonProperty("pst_tax_rate")]
        public decimal PSTTaxRate { get; set; }

        [JsonProperty("pst")]
        public decimal PST { get; set; }

        [JsonProperty("qst_taxable_amount")]
        public decimal QSTTaxableAmount { get; set; }

        [JsonProperty("qst_tax_rate")]
        public decimal QSTTaxRate { get; set; }

        [JsonProperty("qst")]
        public decimal QST { get; set; }
    }
    public class TaxBreakdownShipping : Breakdown
    {
        [JsonProperty("state_sales_tax_rate")]
        public decimal StateSalesTaxRate { get; set; }

        [JsonProperty("state_amount")]
        public decimal StateAmount { get; set; }

        [JsonProperty("county_amount")]
        public decimal CountyAmount { get; set; }

        [JsonProperty("city_amount")]
        public decimal CityAmount { get; set; }

        [JsonProperty("special_taxable_amount")]
        public decimal SpecialDistrictTaxableAmount { get; set; }

        [JsonProperty("special_tax_rate")]
        public decimal SpecialDistrictTaxRate { get; set; }

        [JsonProperty("special_district_amount")]
        public decimal SpecialDistrictAmount { get; set; }
    }
    public class TaxBreakdown : Breakdown
    {
        [JsonProperty("state_tax_rate")]
        public decimal StateTaxRate { get; set; }

        [JsonProperty("state_tax_collectable")]
        public decimal StateTaxCollectable { get; set; }

        [JsonProperty("county_tax_collectable")]
        public decimal CountyTaxCollectable { get; set; }

        [JsonProperty("city_tax_collectable")]
        public decimal CityTaxCollectable { get; set; }

        [JsonProperty("special_district_taxable_amount")]
        public decimal SpecialDistrictTaxableAmount { get; set; }

        [JsonProperty("special_tax_rate")]
        public decimal SpecialDistrictTaxRate { get; set; }

        [JsonProperty("special_district_tax_collectable")]
        public decimal SpecialDistrictTaxCollectable { get; set; }

        [JsonProperty("shipping")]
        public TaxBreakdownShipping Shipping { get; set; }

        [JsonProperty("line_items")]
        public List<TaxBreakdownLineItem> LineItems { get; set; }
    }
    public class TaxBreakdownLineItem : Breakdown
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("state_sales_tax_rate")]
        public decimal StateSalesTaxRate { get; set; }

        [JsonProperty("state_amount")]
        public decimal StateAmount { get; set; }

        [JsonProperty("county_amount")]
        public decimal CountyAmount { get; set; }

        [JsonProperty("city_amount")]
        public decimal CityAmount { get; set; }

        [JsonProperty("special_district_taxable_amount")]
        public decimal SpecialDistrictTaxableAmount { get; set; }

        [JsonProperty("special_tax_rate")]
        public decimal SpecialTaxRate { get; set; }

        [JsonProperty("special_district_amount")]
        public decimal SpecialDistrictAmount { get; set; }
    }
    public class TaxJurisdictions
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("county")]
        public string County { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }
    }
    public class Tax
    {
        [JsonProperty("from_country")]
        public string FromCountry { get; set; }

        [JsonProperty("from_zip")]
        public string FromZip { get; set; }

        [JsonProperty("from_state")]
        public string FromState { get; set; }

        [JsonProperty("from_city")]
        public string FromCity { get; set; }

        [JsonProperty("from_street")]
        public string FromStreet { get; set; }

        [JsonProperty("to_country")]
        public string ToCountry { get; set; }

        [JsonProperty("to_zip")]
        public string ToZip { get; set; }

        [JsonProperty("to_state")]
        public string ToState { get; set; }

        [JsonProperty("to_city")]
        public string ToCity { get; set; }

        [JsonProperty("to_street")]
        public string ToStreet { get; set; }

        [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Amount { get; set; }

        [JsonProperty("shipping", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Shipping { get; set; }

        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        [JsonProperty("exemption_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ExemptionType { get; set; }

        [JsonProperty("nexus_addresses")]
        public List<NexusAddress> NexusAddresses { get; set; }

        [JsonProperty("line_items")]
        public List<TaxLineItem> LineItems { get; set; }
    }

    public class NexusAddress
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }
    }
    public class TaxLineItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("product_tax_code")]
        public string ProductTaxCode { get; set; }

        [JsonProperty("unit_price")]
        public decimal UnitPrice { get; set; }

        [JsonProperty("discount")]
        public decimal Discount { get; set; }
    }
}
