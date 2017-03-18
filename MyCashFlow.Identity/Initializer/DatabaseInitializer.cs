using MyCashFlow.Domains.DataObject;
using MyCashFlow.Identity.Context;
using MyCashFlow.Identity.Stores;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System;

namespace MyCashFlow.Identity.Initializer
{
	// TODO: Change parent to DropCreateDatabaseIfModelChanges before release
	public class DatabaseInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
	{
		protected override void Seed(ApplicationDbContext context)
		{
			AddCountries(context);
			AddPaymentMethods(context);
			AddTransactionTypes(context);
			AddUsers(context);
			AddProjects(context);
			AddTransactions(context);
			AddCurrency(context);
		}

		#region Helpers

		private static void AddCountries(ApplicationDbContext context)
		{
			var countries = new List<Country>
			{
				new Country { Name = "Abkhazia", ISOCode2 = null, ISOCode3 = null, TelephoneCountryCode = 7840 },
				new Country { Name = "Afghanistan", ISOCode2 = "AF", ISOCode3 = "AFG", TelephoneCountryCode = 93 },
				new Country { Name = "Akrotiri and Dhekelia", ISOCode2 = null, ISOCode3 = null, TelephoneCountryCode = 357 },
				new Country { Name = "Albania", ISOCode2 = "AL", ISOCode3 = "ALB", TelephoneCountryCode = 355 },
				new Country { Name = "Alderney", ISOCode2 = null, ISOCode3 = null, TelephoneCountryCode = 44181 },
				new Country { Name = "Algeria", ISOCode2 = "DZ", ISOCode3 = "DZD", TelephoneCountryCode = 213 },
				new Country { Name = "Andorra", ISOCode2 = "AD", ISOCode3 = "AND", TelephoneCountryCode = 376 },
				new Country { Name = "Angola", ISOCode2 = "AO", ISOCode3 = "AGO", TelephoneCountryCode = 244 },
				new Country { Name = "Anguilla", ISOCode2 = "AI", ISOCode3 = "AIA", TelephoneCountryCode = 1264 },
				new Country { Name = "Antigua and Barbuda", ISOCode2 = "AG", ISOCode3 = "ATG", TelephoneCountryCode = 1268 },
				new Country { Name = "Argentina", ISOCode2 = "AR", ISOCode3 = "ARG", TelephoneCountryCode = 54 },
				new Country { Name = "Armenia", ISOCode2 = "AM", ISOCode3 = "ARM", TelephoneCountryCode = 374 },
				new Country { Name = "Aruba", ISOCode2 = "AW", ISOCode3 = "ABW", TelephoneCountryCode =  297},
				new Country { Name = "Ascension Island", ISOCode2 = null, ISOCode3 = null, TelephoneCountryCode = 247 },
				new Country { Name = "Australia", ISOCode2 = "AU", ISOCode3 = "AUS", TelephoneCountryCode = 61 },
				new Country { Name = "Austria", ISOCode2 = "AT", ISOCode3 = "AUT", TelephoneCountryCode = 43 },
				new Country { Name = "Azerbaijan", ISOCode2 = "AZ", ISOCode3 = "AZE", TelephoneCountryCode = 994 },
				new Country { Name = "Bahamas, The", ISOCode2 = "BS", ISOCode3 = "BHS", TelephoneCountryCode = 1242 },
				new Country { Name = "Bahrain", ISOCode2 = "BH", ISOCode3 = "BHR", TelephoneCountryCode = 973 },
				new Country { Name = "Bangladesh", ISOCode2 = "BD", ISOCode3 = "BGD", TelephoneCountryCode = 880 },
				new Country { Name = "Barbados", ISOCode2 = "BB", ISOCode3 = "BRB", TelephoneCountryCode = 1246 },
				new Country { Name = "Belarus", ISOCode2 = "BY", ISOCode3 = "BLR", TelephoneCountryCode = 375 },
				new Country { Name = "Belgium", ISOCode2 = "BE", ISOCode3 = "BEL", TelephoneCountryCode = 32 },
				new Country { Name = "Belize", ISOCode2 = "BZ", ISOCode3 = "BLZ", TelephoneCountryCode = 501 },
				new Country { Name = "Benin", ISOCode2 = "BJ", ISOCode3 = "BEN", TelephoneCountryCode = 229 },
				new Country { Name = "Bermuda", ISOCode2 = "BM", ISOCode3 = "BMU", TelephoneCountryCode = 1441 },
				new Country { Name = "Bhutan", ISOCode2 = "BT", ISOCode3 = "BTN", TelephoneCountryCode = 975 },
				new Country { Name = "Bolivia", ISOCode2 = "BO", ISOCode3 = "BOL", TelephoneCountryCode = 591 },
				new Country { Name = "Bonaire", ISOCode2 = "BQ", ISOCode3 = "BES", TelephoneCountryCode = 5997 },
				new Country { Name = "Bosnia and Herzegovina", ISOCode2 = "BA", ISOCode3 = "BIH", TelephoneCountryCode = 387 },
				new Country { Name = "Botswana", ISOCode2 = "BW", ISOCode3 = "BWA", TelephoneCountryCode = 267 },
				new Country { Name = "Brazil", ISOCode2 = "BR", ISOCode3 = "BRA", TelephoneCountryCode = 55 },
				new Country { Name = "British Indian Ocean Territory", ISOCode2 = "IO", ISOCode3 = "IOT", TelephoneCountryCode = 246 },
				new Country { Name = "British Virgin Islands", ISOCode2 = "VG", ISOCode3 = "VGB", TelephoneCountryCode = 1284 },
				new Country { Name = "Brunei", ISOCode2 = "BN", ISOCode3 = "BRN", TelephoneCountryCode = 673 },
				new Country { Name = "Bulgaria", ISOCode2 = "BG", ISOCode3 = "BGR", TelephoneCountryCode = 359 },
				new Country { Name = "Burkina Faso", ISOCode2 = "BF", ISOCode3 = "BFA", TelephoneCountryCode = 226 },
				new Country { Name = "Burma", ISOCode2 = "MM", ISOCode3 = "MMR", TelephoneCountryCode = 95 },
				new Country { Name = "Burundi", ISOCode2 = "BI", ISOCode3 = "BDI", TelephoneCountryCode = 257 },
				new Country { Name = "Cambodia", ISOCode2 = "KH", ISOCode3 = "KHM", TelephoneCountryCode = 855 },
				new Country { Name = "Cameroon", ISOCode2 = "CM", ISOCode3 = "CMR", TelephoneCountryCode = 237 },
				new Country { Name = "Canada", ISOCode2 = "CA", ISOCode3 = "CAN", TelephoneCountryCode = 1 },
				new Country { Name = "Cape Verde", ISOCode2 = "CV", ISOCode3 = "CPV", TelephoneCountryCode = 238 },
				new Country { Name = "Cayman Islands", ISOCode2 = "KY", ISOCode3 = "CYM", TelephoneCountryCode = 1345 },
				new Country { Name = "Central African Republic", ISOCode2 = "CF", ISOCode3 = "CAF", TelephoneCountryCode = 236 },
				new Country { Name = "Chad", ISOCode2 = "TD", ISOCode3 = "TCD", TelephoneCountryCode = 235 },
				new Country { Name = "Chile", ISOCode2 = "CL", ISOCode3 = "CHL", TelephoneCountryCode = 56 },
				new Country { Name = "China, People's Republic of", ISOCode2 = "CN", ISOCode3 = "CHN", TelephoneCountryCode = 86 },
				new Country { Name = "Cocos (Keeling) Islands", ISOCode2 = "CC", ISOCode3 = "CCK", TelephoneCountryCode = 61 },
				new Country { Name = "Colombia", ISOCode2 = "CO", ISOCode3 = "COL", TelephoneCountryCode = 57 },
				new Country { Name = "Comoros", ISOCode2 = "KM", ISOCode3 = "COM", TelephoneCountryCode = 269 },
				new Country { Name = "Congo, Democratic Republic of the", ISOCode2 = "CD", ISOCode3 = "COD", TelephoneCountryCode = 243 },
				new Country { Name = "Congo, Republic of the", ISOCode2 = "CG", ISOCode3 = "COG", TelephoneCountryCode = 242 },
				new Country { Name = "Cook Islands", ISOCode2 = "CK", ISOCode3 = "COK", TelephoneCountryCode = 682 },
				new Country { Name = "Costa Rica", ISOCode2 = "CR", ISOCode3 = "CRC", TelephoneCountryCode = 506 },
				new Country { Name = "Côte d'Ivoire", ISOCode2 = "CI", ISOCode3 = "CIV", TelephoneCountryCode = 225 },
				new Country { Name = "Croatia", ISOCode2 = "HR", ISOCode3 = "HRV", TelephoneCountryCode = 385 },
				new Country { Name = "Cuba", ISOCode2 = "CU", ISOCode3 = "CUB", TelephoneCountryCode = 53 },
				new Country { Name = "Curaçao", ISOCode2 = "CW", ISOCode3 = "CUW", TelephoneCountryCode = 5999 },
				new Country { Name = "Cyprus", ISOCode2 = "CY", ISOCode3 = "CYP", TelephoneCountryCode = 357 },
				new Country { Name = "Czech Republic", ISOCode2 = "CZ", ISOCode3 = "CZE", TelephoneCountryCode = 420 },
				new Country { Name = "Denmark", ISOCode2 = "DK", ISOCode3 = "DNK", TelephoneCountryCode = 45 },
				new Country { Name = "Djibouti", ISOCode2 = "DJ", ISOCode3 = "DJI", TelephoneCountryCode = 253 },
				new Country { Name = "Dominica", ISOCode2 = "DM", ISOCode3 = "DMA", TelephoneCountryCode = 1767 },
				new Country { Name = "Dominican Republic", ISOCode2 = "DO", ISOCode3 = "DOM", TelephoneCountryCode = 1809 },
				new Country { Name = "East Timor", ISOCode2 = "TL", ISOCode3 = "TLS", TelephoneCountryCode = 670 },
				new Country { Name = "Ecuador", ISOCode2 = "EC", ISOCode3 = "ECU", TelephoneCountryCode = 593 },
				new Country { Name = "Egypt", ISOCode2 = "EG", ISOCode3 = "EGY", TelephoneCountryCode = 20 },
				new Country { Name = "El Salvador", ISOCode2 = "SV", ISOCode3 = "SLV", TelephoneCountryCode = 503 },
				new Country { Name = "Equatorial Guinea", ISOCode2 = "GQ", ISOCode3 = "GNQ", TelephoneCountryCode = 240 },
				new Country { Name = "Eritrea", ISOCode2 = "ER", ISOCode3 = "ERI", TelephoneCountryCode = 291 },
				new Country { Name = "Estonia", ISOCode2 = "EE", ISOCode3 = "EST", TelephoneCountryCode = 372 },
				new Country { Name = "Ethiopia", ISOCode2 = "ET", ISOCode3 = "ETH", TelephoneCountryCode = 251 },
				new Country { Name = "Falkland Islands", ISOCode2 = "FK", ISOCode3 = "FLK", TelephoneCountryCode = 500 },
				new Country { Name = "Faroe Islands", ISOCode2 = "FO", ISOCode3 = "FRO", TelephoneCountryCode = 298 },
				new Country { Name = "Fiji", ISOCode2 = "FJ", ISOCode3 = "FJI", TelephoneCountryCode = 679 },
				new Country { Name = "Finland", ISOCode2 = "FI", ISOCode3 = "FIN", TelephoneCountryCode = 358 },
				new Country { Name = "France", ISOCode2 = "FR", ISOCode3 = "FRA", TelephoneCountryCode = 33 },
				new Country { Name = "French Polynesia", ISOCode2 = "PF", ISOCode3 = "PYF", TelephoneCountryCode = 689 },
				new Country { Name = "Gabon", ISOCode2 = "GA", ISOCode3 = "GAB", TelephoneCountryCode = 241 },
				new Country { Name = "Gambia, The", ISOCode2 = "GM", ISOCode3 = "GMB", TelephoneCountryCode = 220 },
				new Country { Name = "Georgia", ISOCode2 = "GE", ISOCode3 = "GEO", TelephoneCountryCode = 995 },
				new Country { Name = "Germany", ISOCode2 = "DE", ISOCode3 = "DEU", TelephoneCountryCode = 49 },
				new Country { Name = "Ghana", ISOCode2 = "GH", ISOCode3 = "GHA", TelephoneCountryCode = 233 },
				new Country { Name = "Gibraltar", ISOCode2 = "GI", ISOCode3 = "GIB", TelephoneCountryCode = 350 },
				new Country { Name = "Greece", ISOCode2 = "GR", ISOCode3 = "GRC", TelephoneCountryCode = 30 },
				new Country { Name = "Grenada", ISOCode2 = "GD", ISOCode3 = "GRD", TelephoneCountryCode = 1473 },
				new Country { Name = "Guatemala", ISOCode2 = "GT", ISOCode3 = "GTM", TelephoneCountryCode = 502 },
				new Country { Name = "Guernsey", ISOCode2 = "GG", ISOCode3 = "GGY", TelephoneCountryCode = 44 },
				new Country { Name = "Guinea", ISOCode2 = "GN", ISOCode3 = "GIN", TelephoneCountryCode = 224 },
				new Country { Name = "Guinea-Bissau", ISOCode2 = "GW", ISOCode3 = "GNB", TelephoneCountryCode = 245 },
				new Country { Name = "Guyana", ISOCode2 = "GY", ISOCode3 = "GUY", TelephoneCountryCode = 592 },
				new Country { Name = "Haiti", ISOCode2 = "HT", ISOCode3 = "HTI", TelephoneCountryCode = 509 },
				new Country { Name = "Honduras", ISOCode2 = "HN", ISOCode3 = "HND", TelephoneCountryCode = 504 },
				new Country { Name = "Hong Kong", ISOCode2 = "HK", ISOCode3 = "HKG", TelephoneCountryCode = 852 },
				new Country { Name = "Hungary", ISOCode2 = "HU", ISOCode3 = "HUN", TelephoneCountryCode = 36 },
				new Country { Name = "Iceland", ISOCode2 = "IS", ISOCode3 = "ISL", TelephoneCountryCode = 354 },
				new Country { Name = "India", ISOCode2 = "IN", ISOCode3 = "IND", TelephoneCountryCode = 91 },
				new Country { Name = "Indonesia", ISOCode2 = "ID", ISOCode3 = "IDN", TelephoneCountryCode = 62 },
				new Country { Name = "Iran", ISOCode2 = "IR", ISOCode3 = "IRN", TelephoneCountryCode = 98 },
				new Country { Name = "Iraq", ISOCode2 = "IQ", ISOCode3 = "IRQ", TelephoneCountryCode = 964 },
				new Country { Name = "Ireland", ISOCode2 = "IE", ISOCode3 = "IRL", TelephoneCountryCode = 353 },
				new Country { Name = "Isle of Man", ISOCode2 = "IM", ISOCode3 = "IMN", TelephoneCountryCode = 44 },
				new Country { Name = "Israel", ISOCode2 = "IL", ISOCode3 = "ISR", TelephoneCountryCode = 972 },
				new Country { Name = "Italy", ISOCode2 = "IT", ISOCode3 = "ITA", TelephoneCountryCode = 39 },
				new Country { Name = "Jamaica", ISOCode2 = "JM", ISOCode3 = "JAM", TelephoneCountryCode = 1876 },
				new Country { Name = "Japan", ISOCode2 = "JP", ISOCode3 = "JPN", TelephoneCountryCode = 81 },
				new Country { Name = "Jersey", ISOCode2 = "JE", ISOCode3 = "JEY", TelephoneCountryCode = 44 },
				new Country { Name = "Jordan", ISOCode2 = "JO", ISOCode3 = "JOR", TelephoneCountryCode = 962 },
				new Country { Name = "Kazakhstan", ISOCode2 = "KZ", ISOCode3 = "KAZ", TelephoneCountryCode = 7 },
				new Country { Name = "Kenya", ISOCode2 = "KE", ISOCode3 = "KEN", TelephoneCountryCode = 254 },
				new Country { Name = "Kiribati", ISOCode2 = "KI", ISOCode3 = "KIR", TelephoneCountryCode = 686 },
				new Country { Name = "Korea, North", ISOCode2 = "KP", ISOCode3 = "PRK", TelephoneCountryCode = 850 },
				new Country { Name = "Korea, South", ISOCode2 = "KR", ISOCode3 = "KOR", TelephoneCountryCode = 82 },
				new Country { Name = "Kosovo", ISOCode2 = "XK", ISOCode3 = null, TelephoneCountryCode = 381 },
				new Country { Name = "Kuwait", ISOCode2 = "KW", ISOCode3 = "KWT", TelephoneCountryCode = 965 },
				new Country { Name = "Kyrgyzstan", ISOCode2 = "KG", ISOCode3 = "KGZ", TelephoneCountryCode = 996 },
				new Country { Name = "Laos", ISOCode2 = "LA", ISOCode3 = "LAO", TelephoneCountryCode = 856 },
				new Country { Name = "Latvia", ISOCode2 = "LV", ISOCode3 = "LVA", TelephoneCountryCode = 371 },
				new Country { Name = "Lebanon", ISOCode2 = "LB", ISOCode3 = "LBN", TelephoneCountryCode = 961 },
				new Country { Name = "Lesotho", ISOCode2 = "LS", ISOCode3 = "LSO", TelephoneCountryCode = 266 },
				new Country { Name = "Liberia", ISOCode2 = "LR", ISOCode3 = "LBR", TelephoneCountryCode = 231 },
				new Country { Name = "Libya", ISOCode2 = "LY", ISOCode3 = "LBY", TelephoneCountryCode = 218 },
				new Country { Name = "Liechtenstein", ISOCode2 = "LI", ISOCode3 = "LIE", TelephoneCountryCode = 423 },
				new Country { Name = "Lithuania", ISOCode2 = "LT", ISOCode3 = "LTU", TelephoneCountryCode = 370 },
				new Country { Name = "Luxembourg", ISOCode2 = "LU", ISOCode3 = "LUX", TelephoneCountryCode = 352 },
				new Country { Name = "Macau", ISOCode2 = "MO", ISOCode3 = "MAC", TelephoneCountryCode = 853 },
				new Country { Name = "Macedonia, Republic of", ISOCode2 = "MK", ISOCode3 = "MKD", TelephoneCountryCode = 389 },
				new Country { Name = "Madagascar", ISOCode2 = "MG", ISOCode3 = "MDG", TelephoneCountryCode = 261 },
				new Country { Name = "Malawi", ISOCode2 = "MW", ISOCode3 = "MWI", TelephoneCountryCode = 265 },
				new Country { Name = "Malaysia", ISOCode2 = "MY", ISOCode3 = "MYS", TelephoneCountryCode = 60 },
				new Country { Name = "Maldives", ISOCode2 = "MV", ISOCode3 = "MDV", TelephoneCountryCode = 960 },
				new Country { Name = "Mali", ISOCode2 = "ML", ISOCode3 = "MLI", TelephoneCountryCode = 223 },
				new Country { Name = "Malta", ISOCode2 = "MT", ISOCode3 = "MLT", TelephoneCountryCode = 356 },
				new Country { Name = "Marshall Islands", ISOCode2 = "MH", ISOCode3 = "MHL", TelephoneCountryCode = 692 },
				new Country { Name = "Mauritania", ISOCode2 = "MR", ISOCode3 = "MRT", TelephoneCountryCode = 222 },
				new Country { Name = "Mauritius", ISOCode2 = "MU", ISOCode3 = "MUS", TelephoneCountryCode = 230 },
				new Country { Name = "Mexico", ISOCode2 = "MX", ISOCode3 = "MEX", TelephoneCountryCode = 52 },
				new Country { Name = "Micronesia", ISOCode2 = "FM", ISOCode3 = "FSM", TelephoneCountryCode = 691 },
				new Country { Name = "Moldova", ISOCode2 = "MD", ISOCode3 = "MDA", TelephoneCountryCode = 373 },
				new Country { Name = "Monaco", ISOCode2 = "MC", ISOCode3 = "MCO", TelephoneCountryCode = 377 },
				new Country { Name = "Mongolia", ISOCode2 = "MN", ISOCode3 = "MNG", TelephoneCountryCode = 976 },
				new Country { Name = "Montenegro", ISOCode2 = "ME", ISOCode3 = "MNE", TelephoneCountryCode = 382 },
				new Country { Name = "Montserrat", ISOCode2 = "MS", ISOCode3 = "MSR", TelephoneCountryCode = 1664 },
				new Country { Name = "Morocco", ISOCode2 = "MA", ISOCode3 = "MAR", TelephoneCountryCode = 212 },
				new Country { Name = "Mozambique", ISOCode2 = "MZ", ISOCode3 = "MOZ", TelephoneCountryCode = 258 },
				new Country { Name = "Nagorno-Karabakh Republic", ISOCode2 = null, ISOCode3 = null, TelephoneCountryCode = 37447 },
				new Country { Name = "Namibia", ISOCode2 = "NA", ISOCode3 = "NAM", TelephoneCountryCode = 264 },
				new Country { Name = "Nauru", ISOCode2 = "NR", ISOCode3 = "NRU", TelephoneCountryCode = 674 },
				new Country { Name = "Nepal", ISOCode2 = "NP", ISOCode3 = "NPL", TelephoneCountryCode = 977 },
				new Country { Name = "Netherlands", ISOCode2 = "NL", ISOCode3 = "NLD", TelephoneCountryCode = 31 },
				new Country { Name = "New Caledonia", ISOCode2 = "NC", ISOCode3 = "NCL", TelephoneCountryCode = 687 },
				new Country { Name = "New Zealand", ISOCode2 = "NZ", ISOCode3 = "NZL", TelephoneCountryCode = 64 },
				new Country { Name = "Nicaragua", ISOCode2 = "NI", ISOCode3 = "NIC", TelephoneCountryCode = 505 },
				new Country { Name = "Niger", ISOCode2 = "NE", ISOCode3 = "NER", TelephoneCountryCode = 227 },
				new Country { Name = "Nigeria", ISOCode2 = "NG", ISOCode3 = "NGA", TelephoneCountryCode = 234 },
				new Country { Name = "Niue", ISOCode2 = "NU", ISOCode3 = "NIU", TelephoneCountryCode = 683 },
				new Country { Name = "Northern Cyprus", ISOCode2 = null, ISOCode3 = null, TelephoneCountryCode = 90392 },
				new Country { Name = "Norway", ISOCode2 = "NO", ISOCode3 = "NOR", TelephoneCountryCode = 47 },
				new Country { Name = "Oman", ISOCode2 = "OM", ISOCode3 = "OMN", TelephoneCountryCode = 968 },
				new Country { Name = "Pakistan", ISOCode2 = "PK", ISOCode3 = "PAK", TelephoneCountryCode = 92 },
				new Country { Name = "Palau", ISOCode2 = "PW", ISOCode3 = "PLW", TelephoneCountryCode = 680 },
				new Country { Name = "Palestine", ISOCode2 = "PS", ISOCode3 = "PSE", TelephoneCountryCode = 970 },
				new Country { Name = "Panama", ISOCode2 = "PA", ISOCode3 = "PAN", TelephoneCountryCode = 507 },
				new Country { Name = "Papua New Guinea", ISOCode2 = "PG", ISOCode3 = "PNG", TelephoneCountryCode = 675 },
				new Country { Name = "Paraguay", ISOCode2 = "PY", ISOCode3 = "PRY", TelephoneCountryCode = 595 },
				new Country { Name = "Peru", ISOCode2 = "PE", ISOCode3 = "PER", TelephoneCountryCode = 51 },
				new Country { Name = "Philippines", ISOCode2 = "PH", ISOCode3 = "PHL", TelephoneCountryCode = 63 },
				new Country { Name = "Pitcairn Islands", ISOCode2 = "PN", ISOCode3 = "PCN", TelephoneCountryCode = 870 },
				new Country { Name = "Poland", ISOCode2 = "PL", ISOCode3 = "PLN", TelephoneCountryCode = 48 },
				new Country { Name = "Portugal", ISOCode2 = "PT", ISOCode3 = "PRT", TelephoneCountryCode = 351 },
				new Country { Name = "Qatar", ISOCode2 = "QA", ISOCode3 = "QAT", TelephoneCountryCode = 974 },
				new Country { Name = "Romania", ISOCode2 = "RO", ISOCode3 = "ROU", TelephoneCountryCode = 40 },
				new Country { Name = "Russia", ISOCode2 = "RU", ISOCode3 = "RUS", TelephoneCountryCode = 7 },
				new Country { Name = "Rwanda", ISOCode2 = "RW", ISOCode3 = "RWA", TelephoneCountryCode = 250 },
				new Country { Name = "Saba", ISOCode2 = "BQ", ISOCode3 = null, TelephoneCountryCode = 5994 },
				new Country { Name = "Sahrawi Republic", ISOCode2 = null, ISOCode3 = null, TelephoneCountryCode = null },
				new Country { Name = "Saint Helena", ISOCode2 = "SH", ISOCode3 = "SHN", TelephoneCountryCode = 290 },
				new Country { Name = "Saint Kitts and Nevis", ISOCode2 = "KN", ISOCode3 = "KNA", TelephoneCountryCode = 1869 },
				new Country { Name = "Saint Lucia", ISOCode2 = "LC", ISOCode3 = "LCA", TelephoneCountryCode = 1758 },
				new Country { Name = "Saint Vincent and the Grenadines", ISOCode2 = "VC", ISOCode3 = "VCT", TelephoneCountryCode = 1784 },
				new Country { Name = "Samoa", ISOCode2 = "WS", ISOCode3 = "WSM", TelephoneCountryCode = 685 },
				new Country { Name = "San Marino", ISOCode2 = "SM", ISOCode3 = "SMR", TelephoneCountryCode = 378 },
				new Country { Name = "São Tomé and Príncipe", ISOCode2 = "ST", ISOCode3 = "STP", TelephoneCountryCode = 239 },
				new Country { Name = "Saudi Arabia", ISOCode2 = "SA", ISOCode3 = "SAU", TelephoneCountryCode = 966 },
				new Country { Name = "Senegal", ISOCode2 = "SN", ISOCode3 = "SEN", TelephoneCountryCode = 221 },
				new Country { Name = "Serbia", ISOCode2 = "RS", ISOCode3 = "SRB", TelephoneCountryCode = 381 },
				new Country { Name = "Seychelles", ISOCode2 = "SC", ISOCode3 = "SYC", TelephoneCountryCode = 248 },
				new Country { Name = "Sierra Leone", ISOCode2 = "SL", ISOCode3 = "SLE", TelephoneCountryCode = 232 },
				new Country { Name = "Singapore", ISOCode2 = "SG", ISOCode3 = "SGP", TelephoneCountryCode = 65 },
				new Country { Name = "Sint Eustatius", ISOCode2 = "BQ", ISOCode3 = "BES", TelephoneCountryCode = 5993 },
				new Country { Name = "Sint Maarten", ISOCode2 = "SX", ISOCode3 = "SXM", TelephoneCountryCode = 1721 },
				new Country { Name = "Slovakia", ISOCode2 = "SK", ISOCode3 = "SVK", TelephoneCountryCode = 421 },
				new Country { Name = "Slovenia", ISOCode2 = "SI", ISOCode3 = "SVN", TelephoneCountryCode = 386 },
				new Country { Name = "Solomon Islands", ISOCode2 = "SB", ISOCode3 = "SLB", TelephoneCountryCode = 677 },
				new Country { Name = "Somalia", ISOCode2 = "SO", ISOCode3 = "SOM", TelephoneCountryCode = 252 },
				new Country { Name = "Somaliland", ISOCode2 = null, ISOCode3 = null, TelephoneCountryCode = 252 },
				new Country { Name = "South Africa", ISOCode2 = "ZA", ISOCode3 = "ZAF", TelephoneCountryCode = 27 },
				new Country { Name = "South Georgia and the South Sandwich Islands", ISOCode2 = "GS", ISOCode3 = "SGS", TelephoneCountryCode = 500 },
				new Country { Name = "South Ossetia", ISOCode2 = null, ISOCode3 = null, TelephoneCountryCode = 99534 },
				new Country { Name = "Spain", ISOCode2 = "ES", ISOCode3 = "ESP", TelephoneCountryCode = 34 },
				new Country { Name = "South Sudan", ISOCode2 = "SS", ISOCode3 = "SSD", TelephoneCountryCode = 211 },
				new Country { Name = "Sri Lanka", ISOCode2 = "LK", ISOCode3 = "LKA", TelephoneCountryCode = 94 },
				new Country { Name = "Sudan", ISOCode2 = "SD", ISOCode3 = "SDN", TelephoneCountryCode = 249 },
				new Country { Name = "Suriname", ISOCode2 = "SR", ISOCode3 = "SUR", TelephoneCountryCode = 597 },
				new Country { Name = "Swaziland", ISOCode2 = "SZ", ISOCode3 = "SWZ", TelephoneCountryCode = 268 },
				new Country { Name = "Sweden", ISOCode2 = "SE", ISOCode3 = "SWE", TelephoneCountryCode = 46 },
				new Country { Name = "Switzerland", ISOCode2 = "CH", ISOCode3 = "CHE", TelephoneCountryCode = 41 },
				new Country { Name = "Syria", ISOCode2 = "SY", ISOCode3 = "SYR", TelephoneCountryCode = 963 },
				new Country { Name = "Taiwan", ISOCode2 = "TW", ISOCode3 = "TWN", TelephoneCountryCode = 886 },
				new Country { Name = "Tajikistan", ISOCode2 = "TJ", ISOCode3 = "TJK", TelephoneCountryCode = 992 },
				new Country { Name = "Tanzania", ISOCode2 = "TZ", ISOCode3 = "TZA", TelephoneCountryCode = 255 },
				new Country { Name = "Thailand", ISOCode2 = "TH", ISOCode3 = "THA", TelephoneCountryCode = 66 },
				new Country { Name = "Togo", ISOCode2 = "TG", ISOCode3 = "TGO", TelephoneCountryCode = 228 },
				new Country { Name = "Tonga", ISOCode2 = "TO", ISOCode3 = "TON", TelephoneCountryCode = 676 },
				new Country { Name = "Transnistria", ISOCode2 = null, ISOCode3 = null, TelephoneCountryCode = 373 },
				new Country { Name = "Trinidad and Tobago", ISOCode2 = "TT", ISOCode3 = "TTO", TelephoneCountryCode = 1868 },
				new Country { Name = "Tristan da Cunha", ISOCode2 = "SH", ISOCode3 = "SHN", TelephoneCountryCode = 290 },
				new Country { Name = "Tunisia", ISOCode2 = "TN", ISOCode3 = "TUN", TelephoneCountryCode = 216 },
				new Country { Name = "Turkey", ISOCode2 = "TR", ISOCode3 = "TUR", TelephoneCountryCode = 90 },
				new Country { Name = "Turkmenistan", ISOCode2 = "TM", ISOCode3 = "TKM", TelephoneCountryCode = 993 },
				new Country { Name = "Turks and Caicos Islands", ISOCode2 = "TC", ISOCode3 = "TCA", TelephoneCountryCode = 1649 },
				new Country { Name = "Tuvalu", ISOCode2 = "TV", ISOCode3 = "TUV", TelephoneCountryCode = 688 },
				new Country { Name = "Uganda", ISOCode2 = "UG", ISOCode3 = "UGA", TelephoneCountryCode = 256 },
				new Country { Name = "Ukraine", ISOCode2 = "UA", ISOCode3 = "UKR", TelephoneCountryCode = 380 },
				new Country { Name = "United Arab Emirates", ISOCode2 = "AE", ISOCode3 = "ARE", TelephoneCountryCode = 971 },
				new Country { Name = "United Kingdom", ISOCode2 = "GB", ISOCode3 = "GBR", TelephoneCountryCode = 44 },
				new Country { Name = "United States", ISOCode2 = "US", ISOCode3 = "USA", TelephoneCountryCode = 1 },
				new Country { Name = "Uruguay", ISOCode2 = "UY", ISOCode3 = "URY", TelephoneCountryCode = 598 },
				new Country { Name = "Uzbekistan", ISOCode2 = "UZ", ISOCode3 = "UZB", TelephoneCountryCode = 998 },
				new Country { Name = "Vanuatu", ISOCode2 = "VU", ISOCode3 = "VUT", TelephoneCountryCode = 678 },
				new Country { Name = "Vatican City", ISOCode2 = "VA", ISOCode3 = "VAT", TelephoneCountryCode = 379 },
				new Country { Name = "Venezuela", ISOCode2 = "VE", ISOCode3 = "VEN", TelephoneCountryCode = 58 },
				new Country { Name = "Vietnam", ISOCode2 = "VN", ISOCode3 = "VNM", TelephoneCountryCode = 84 },
				new Country { Name = "Wallis and Futuna", ISOCode2 = "WF", ISOCode3 = "WLF", TelephoneCountryCode = 681 },
				new Country { Name = "Yemen", ISOCode2 = "YE", ISOCode3 = "YEM", TelephoneCountryCode = 967 },
				new Country { Name = "Zambia", ISOCode2 = "ZM", ISOCode3 = "ZMB", TelephoneCountryCode = 260 },
				new Country { Name = "Zimbabwe", ISOCode2 = "ZW", ISOCode3 = "ZWE", TelephoneCountryCode = 263 }
			};

			countries.ForEach(c => context.Countries.Add(c));
			context.SaveChanges();
		}

		private static void AddPaymentMethods(ApplicationDbContext context)
		{
			var paymentMethods = new List<PaymentMethod>
			{
				new PaymentMethod { Name = "Cash" },
				new PaymentMethod { Name = "Credit card" },
				new PaymentMethod { Name = "Debit card" },
				new PaymentMethod { Name = "Cheque" },
				new PaymentMethod { Name = "Money transfer" },
				new PaymentMethod { Name = "Mobile payment" }
			};

			paymentMethods.ForEach(pm => context.PaymentMethods.Add(pm));
			context.SaveChanges();
		}

		private static void AddTransactionTypes(ApplicationDbContext context)
		{
			var transactionTypes = new List<TransactionType>
			{
				new TransactionType { Name = "Transportation" },
				new TransactionType { Name = "Bank" },
				new TransactionType { Name = "Insurance" },
				new TransactionType { Name = "Living" },
				new TransactionType { Name = "Household" },
				new TransactionType { Name = "Travel & Leisure" },
				new TransactionType { Name = "Salary" },
				new TransactionType { Name = "Groceries" },
				new TransactionType { Name = "Gift" },
				new TransactionType { Name = "Savings" },
				new TransactionType { Name = "Other" }
			};

			transactionTypes.ForEach(tt => context.TransactionTypes.Add(tt));
			context.SaveChanges();
		}

		private static void AddUsers(ApplicationDbContext context)
		{
			var user = new User
			{
				UserName = "username",
				Gender = Domains.Artificial.Gender.Male,
				FirstName = "First name",
				MiddleName = "Middle name",
				LastName = "Last name",
				AddressLine1 = "Address line 1",
				AddressLine2 = "Address Line 2",
				City = "City",
				Zip = "Zip",
				District = "District",
				MobileNumber = "Mobile number",
				CountryID = context.Countries.First(x => x.Name == "Slovakia").ID
			};

			var userStore = new CustomUserStore(context);
			var userManager = new Microsoft.AspNet.Identity.UserManager<User, int>(userStore);
			var result = userManager.CreateAsync(user, "Heslo1<>").Result;
		}

		private static void AddProjects(ApplicationDbContext context)
		{
			var creatorID = context.Users.First(x => x.UserName == "username").Id;

			var projects = new List<Project>
			{
				new Project
				{
					Name = "Test project 1",
					ValidFrom = DateTime.Now.AddMonths(-1).Date,
					ValidTill = DateTime.Now.AddMonths(1).Date,
					Budget = 3500,
					TargetValue = null,
					ActualValue = 3500,
					SequenceNumber = 3,
					CreatorID = creatorID
				},
				new Project
				{
					Name = "Test project 2",
					ValidFrom = DateTime.Now.AddMonths(-2).Date,
					ValidTill = null,
					Budget = null,
					TargetValue = 1000,
					ActualValue = 100,
					SequenceNumber = 1,
					CreatorID = creatorID
				},
				new Project
				{
					Name = "Test project 3",
					ValidFrom = null,
					ValidTill = DateTime.Now.AddMonths(2).Date,
					Budget = null,
					TargetValue = 1000,
					ActualValue = 750,
					SequenceNumber = 4,
					CreatorID = creatorID
				},
				new Project
				{
					Name = "Test project 4",
					ValidFrom = null,
					ValidTill = DateTime.Now.AddDays(-10).Date,
					Budget = 10000,
					TargetValue = null,
					ActualValue = 5000,
					SequenceNumber = 5,
					CreatorID = creatorID
				},
				new Project
				{
					Name = "Test project 5",
					ValidFrom = null,
					ValidTill = null,
					Budget = null,
					TargetValue = null,
					ActualValue = 0,
					SequenceNumber = 2,
					CreatorID = creatorID
				}
			};

			projects.ForEach(p => context.Projects.Add(p));
			context.SaveChanges();
		}

		private static void AddTransactions(ApplicationDbContext context)
		{
			var creatorID = context.Users.First(x => x.UserName == "username").Id;
			var projectID = context.Projects.First(x => x.Name == "Test project 1").ProjectID;

			var transactions = new List<Transaction>
			{
				new Transaction
				{
					Date = DateTime.Now.AddDays(-7).Date,
					Amount = 15.49M,
					Note = "Test transaction 1 for project 1",
					Income = false,
					ProjectID = projectID,
					CreatorID = creatorID,
					TransactionTypeID = context.TransactionTypes.First(x => x.Name == "Transportation").TransactionTypeID,
					PaymentMethodID = context.PaymentMethods.First(x => x.Name == "Cash").PaymentMethodID
				},
				new Transaction
				{
					Date = DateTime.Now.AddDays(-6).Date,
					Amount = 5000M,
					Note = "Test transaction 2 for project 1",
					Income = true,
					ProjectID = projectID,
					CreatorID = creatorID,
					TransactionTypeID = context.TransactionTypes.First(x => x.Name == "Salary").TransactionTypeID,
					PaymentMethodID = context.PaymentMethods.First(x => x.Name == "Money transfer").PaymentMethodID
				},
				new Transaction
				{
					Date = DateTime.Now.AddDays(-5).Date,
					Amount = 142M,
					Note = "Test transaction 1 without project",
					Income = false,
					ProjectID = null,
					CreatorID = creatorID,
					TransactionTypeID = context.TransactionTypes.First(x => x.Name == "Gift").TransactionTypeID,
					PaymentMethodID = context.PaymentMethods.First(x => x.Name == "Credit card").PaymentMethodID
				},
				new Transaction
				{
					Date = DateTime.Now.AddDays(-5).Date,
					Amount = 5M,
					Note = "Test transaction 2 without project",
					Income = false,
					ProjectID = null,
					CreatorID = creatorID,
					TransactionTypeID = context.TransactionTypes.First(x => x.Name == "Transportation").TransactionTypeID,
					PaymentMethodID = context.PaymentMethods.First(x => x.Name == "Mobile payment").PaymentMethodID
				}
			};

			transactions.ForEach(t => context.Transactions.Add(t));
			context.SaveChanges();
		}

		private static void AddCurrency(ApplicationDbContext context)
		{
			var currencies = new List<Currency>
			{
				new Currency { Name = "Abkhazian apsar", ISOCode = null, Sign = null },
				new Currency { Name = "Russian ruble", ISOCode = "RUB", Sign = "руб.", FractionalUnit = "Kopek", FractionalUnitAmount = 100 },
				new Currency { Name = "Afghan afghani", ISOCode = "AFN", Sign = "؋", FractionalUnit = "Pul", FractionalUnitAmount = 100 },
				new Currency { Name = "Euro", ISOCode = "EUR", Sign = "€", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Albanian lek", ISOCode = "ALL", Sign = "L", FractionalUnit = "Qindarkë", FractionalUnitAmount = 100 },
				new Currency { Name = "Alderney pound", ISOCode = null, Sign = "£", FractionalUnit = "Penny", FractionalUnitAmount = 100 },
				new Currency { Name = "British pound", ISOCode = "GBP", Sign = "£", FractionalUnit = "Penny", FractionalUnitAmount = 100 },
				new Currency { Name = "Guernsey pound", ISOCode = "GGP", Sign = "£", FractionalUnit = "Penny", FractionalUnitAmount = 100 },
				new Currency { Name = "Algerian dinar", ISOCode = "DZD", Sign = "د.ج", FractionalUnit = "Santeem", FractionalUnitAmount = 100 },
				new Currency { Name = "Angolan kwanza", ISOCode = "AOA", Sign = "Kz", FractionalUnit = "Cêntimo", FractionalUnitAmount = 100 },
				new Currency { Name = "East Caribbean dollar", ISOCode = "XCD", Sign = "$", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Argentine peso", ISOCode = "ARS", Sign = "$", FractionalUnit = "Centavo", FractionalUnitAmount = 100 },
				new Currency { Name = "Armenian dram", ISOCode = "AMD", Sign = "դր.", FractionalUnit = "Luma", FractionalUnitAmount = 100 },
				new Currency { Name = "Aruban florin", ISOCode = "AWG", Sign = "ƒ", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Ascension pound", ISOCode = null, Sign = "£", FractionalUnit = "Penny", FractionalUnitAmount = 100 },
				new Currency { Name = "Saint Helena pound", ISOCode = "SHP", Sign = "£", FractionalUnit = "Penny", FractionalUnitAmount = 100 },
				new Currency { Name = "Australian dollar", ISOCode = "AUD", Sign = "$", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Azerbaijani manat", ISOCode = "AZN", Sign = "₼", FractionalUnit = "Qəpik", FractionalUnitAmount = 100 },
				new Currency { Name = "Bahamian dollar", ISOCode = "BSD", Sign = "$", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Bahraini dinar", ISOCode = "BHD", Sign = ".د.ب", FractionalUnit = "Fils", FractionalUnitAmount = 1000 },
				new Currency { Name = "Bangladeshi taka", ISOCode = "BDT", Sign = "৳", FractionalUnit = "Paisa", FractionalUnitAmount = 100 },
				new Currency { Name = "Barbadian dollar", ISOCode = "BBD", Sign = "$", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Belarusian ruble", ISOCode = "BYR", Sign = "Br", FractionalUnit = "Kapyeyka", FractionalUnitAmount = 100 },
				new Currency { Name = "Belize dollar", ISOCode = "BZD", Sign = "$", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "West African CFA franc", ISOCode = "XOF", Sign = "Fr", FractionalUnit = "Centime", FractionalUnitAmount = 100 },
				new Currency { Name = "Bermudian dollar", ISOCode = "BMD", Sign = "$", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Bhutanese ngultrum", ISOCode = "BTN", Sign = "Nu.", FractionalUnit = "Chetrum", FractionalUnitAmount = 100 },
				new Currency { Name = "Indian rupee", ISOCode = "INR", Sign = "₹", FractionalUnit = "Paisa", FractionalUnitAmount = 100 },
				new Currency { Name = "Bolivian boliviano", ISOCode = "BOB", Sign = "Bs.", FractionalUnit = "Centavo", FractionalUnitAmount = 100 },
				new Currency { Name = "Bosnia and Herzegovina convertible mark", ISOCode = "BAM", Sign = "КМ", FractionalUnit = "Fening", FractionalUnitAmount = 100 },
				new Currency { Name = "Botswana pula", ISOCode = "BWP", Sign = "P", FractionalUnit = "Thebe", FractionalUnitAmount = 100 },
				new Currency { Name = "Brazilian real", ISOCode = "BRL", Sign = "R$", FractionalUnit = "Centavo", FractionalUnitAmount = 100 },
				new Currency { Name = "British Virgin Islands dollar", ISOCode = null, Sign = "$", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Brunei dollar", ISOCode = "BND", Sign = "$", FractionalUnit = "Sen", FractionalUnitAmount = 100 },
				new Currency { Name = "Singapore dollar", ISOCode = "SGD", Sign = "$", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Bulgarian lev", ISOCode = "BGN", Sign = "лв", FractionalUnit = "Stotinka", FractionalUnitAmount = 100 },
				new Currency { Name = "Burmese kyat", ISOCode = "MMK", Sign = "Ks", FractionalUnit = "Pya", FractionalUnitAmount = 100 },
				new Currency { Name = "Burundian franc", ISOCode = "BIF", Sign = "Fr", FractionalUnit = "Centime", FractionalUnitAmount = 100 },
				new Currency { Name = "Cambodian riel", ISOCode = "KHR", Sign = "៛", FractionalUnit = "Sen", FractionalUnitAmount = 100 },
				new Currency { Name = "Canadian dollar", ISOCode = "CAD", Sign = "$", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Cape Verdean escudo", ISOCode = "CVE", Sign = "Esc", FractionalUnit = "Centavo", FractionalUnitAmount = 100 },
				new Currency { Name = "Cayman Islands dollar", ISOCode = "KYD", Sign = "$", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Central African CFA franc", ISOCode = "XAF", Sign = "Fr", FractionalUnit = "Centime", FractionalUnitAmount = 100 },
				new Currency { Name = "Chilean peso", ISOCode = "CLP", Sign = "$", FractionalUnit = "Centavo", FractionalUnitAmount = 100 },
				new Currency { Name = "Chinese yuan", ISOCode = "CNY", Sign = "元", FractionalUnit = "Fen", FractionalUnitAmount = 100 },
				new Currency { Name = "Colombian peso", ISOCode = "COP", Sign = "$", FractionalUnit = "Centavo", FractionalUnitAmount = 100 },
				new Currency { Name = "Comorian franc", ISOCode = "KMF", Sign = "Fr", FractionalUnit = "Centime", FractionalUnitAmount = 100 },
				new Currency { Name = "Congolese franc", ISOCode = "CDF", Sign = "Fr", FractionalUnit = "Centime", FractionalUnitAmount = 100 },
				new Currency { Name = "New Zealand dollar", ISOCode = "NZD", Sign = "$", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Cook Islands dollar", ISOCode = "CKD", Sign = "'$',", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Costa Rican colón", ISOCode = "CRC", Sign = "₡", FractionalUnit = "Céntimo", FractionalUnitAmount = 100 },
				new Currency { Name = "Croatian kuna", ISOCode = "HRK", Sign = "kn", FractionalUnit = "Lipa", FractionalUnitAmount = 100 },
				new Currency { Name = "Cuban convertible peso", ISOCode = "CUC", Sign = "$", FractionalUnit = "Centavo", FractionalUnitAmount = 100 },
				new Currency { Name = "Cuban peso", ISOCode = "CUP", Sign = "$", FractionalUnit = "Centavo", FractionalUnitAmount = 100 },
				new Currency { Name = "Netherlands Antillean guilder", ISOCode = "ANG", Sign = "ƒ", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Czech koruna", ISOCode = "CZK", Sign = "Kč", FractionalUnit = "Haléř", FractionalUnitAmount = 100 },
				new Currency { Name = "Danish krone", ISOCode = "DKK", Sign = "kr", FractionalUnit = "Øre", FractionalUnitAmount = 100 },
				new Currency { Name = "Djiboutian franc", ISOCode = "DJF", Sign = "Fr", FractionalUnit = "Centime", FractionalUnitAmount = 100 },
				new Currency { Name = "Dominican peso", ISOCode = "DOP", Sign = "$", FractionalUnit = "Centavo", FractionalUnitAmount = 100 },
				new Currency { Name = "United States dollar", ISOCode = "USD", Sign = "$", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Egyptian pound", ISOCode = "EGP", Sign = "ج.م", FractionalUnit = "Piastre", FractionalUnitAmount = 100 },
				new Currency { Name = "Eritrean nakfa", ISOCode = "ERN", Sign = "Nfk", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Ethiopian birr", ISOCode = "ETB", Sign = "Br", FractionalUnit = "Santim", FractionalUnitAmount = 100 },
				new Currency { Name = "Falkland Islands pound", ISOCode = "FKP", Sign = "£", FractionalUnit = "Penny", FractionalUnitAmount = 100 },
				new Currency { Name = "Faroese króna", ISOCode = "FOK", Sign = "kr", FractionalUnit = "Oyra", FractionalUnitAmount = 100 },
				new Currency { Name = "Fijian dollar", ISOCode = "FJD", Sign = "$", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "CFP franc", ISOCode = "XPF", Sign = "Fr", FractionalUnit = "Centime", FractionalUnitAmount = 100 },
				new Currency { Name = "Gambian dalasi", ISOCode = "GMD", Sign = "D", FractionalUnit = "Butut", FractionalUnitAmount = 100 },
				new Currency { Name = "Georgian lari", ISOCode = "GEL", Sign = "ლ", FractionalUnit = "Tetri", FractionalUnitAmount = 100 },
				new Currency { Name = "Ghana cedi", ISOCode = "GHS", Sign = "₵", FractionalUnit = "Pesewa", FractionalUnitAmount = 100 },
				new Currency { Name = "Gibraltar pound", ISOCode = "GIP", Sign = "£", FractionalUnit = "Penny", FractionalUnitAmount = 100 },
				new Currency { Name = "Guatemalan quetzal", ISOCode = "GTQ", Sign = "Q", FractionalUnit = "Centavo", FractionalUnitAmount = 100 },
				new Currency { Name = "Guinean franc", ISOCode = "GNF", Sign = "Fr", FractionalUnit = "Centime", FractionalUnitAmount = 100 },
				new Currency { Name = "Guyanese dollar", ISOCode = "GYD", Sign = "$", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Haitian gourde", ISOCode = "HTG", Sign = "G", FractionalUnit = "Centime", FractionalUnitAmount = 100 },
				new Currency { Name = "Honduran lempira", ISOCode = "HNL", Sign = "L", FractionalUnit = "Centavo", FractionalUnitAmount = 100 },
				new Currency { Name = "Hong Kong dollar", ISOCode = "HKD", Sign = "$", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Hungarian forint", ISOCode = "HUF", Sign = "Ft", FractionalUnit = "Fillér", FractionalUnitAmount = 100 },
				new Currency { Name = "Icelandic króna", ISOCode = "ISK", Sign = "kr", FractionalUnit = "Eyrir", FractionalUnitAmount = 100 },
				new Currency { Name = "Indonesian rupiah", ISOCode = "IDR", Sign = "Rp", FractionalUnit = "Sen", FractionalUnitAmount = 100 },
				new Currency { Name = "Iranian rial", ISOCode = "IRR", Sign = "﷼", FractionalUnit = "Dinar", FractionalUnitAmount = 100 },
				new Currency { Name = "Iraqi dinar", ISOCode = "IQD", Sign = "ع.د", FractionalUnit = "Fils", FractionalUnitAmount = 1000 },
				new Currency { Name = "Manx pound", ISOCode = "IMP", Sign = "£", FractionalUnit = "Penny", FractionalUnitAmount = 100 },
				new Currency { Name = "Israeli new shekel", ISOCode = "ILS", Sign = "₪", FractionalUnit = "Agora", FractionalUnitAmount = 100 },
				new Currency { Name = "Jamaican dollar", ISOCode = "JMD", Sign = "$", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Japanese yen", ISOCode = "JPY", Sign = "¥", FractionalUnit = "Sen", FractionalUnitAmount = 100 },
				new Currency { Name = "Jersey pound", ISOCode = "JEP", Sign = "£", FractionalUnit = "Penny", FractionalUnitAmount = 100 },
				new Currency { Name = "Jordanian dinar", ISOCode = "JOD", Sign = "د.ا", FractionalUnit = "Piastre", FractionalUnitAmount = 100 },
				new Currency { Name = "Kazakhstani tenge", ISOCode = "KZT", Sign = "₸", FractionalUnit = "Tïın", FractionalUnitAmount = 100 },
				new Currency { Name = "Kenyan shilling", ISOCode = "KES", Sign = "Sh", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Kiribati dollar", ISOCode = "KID", Sign = "$", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "North Korean won", ISOCode = "KPW", Sign = "₩", FractionalUnit = "Chon", FractionalUnitAmount = 100 },
				new Currency { Name = "South Korean won", ISOCode = "KRW", Sign = "₩", FractionalUnit = "Jeon", FractionalUnitAmount = 100 },
				new Currency { Name = "Kuwaiti dinar", ISOCode = "KWD", Sign = "د.ك", FractionalUnit = "Fils", FractionalUnitAmount = 1000 },
				new Currency { Name = "Kyrgyzstani som", ISOCode = "KGS", Sign = "лв", FractionalUnit = "Tyiyn", FractionalUnitAmount = 100 },
				new Currency { Name = "Lao kip", ISOCode = "LAK", Sign = "₭", FractionalUnit = "Att", FractionalUnitAmount = 100 },
				new Currency { Name = "Lebanese pound", ISOCode = "LBP", Sign = "ل.ل", FractionalUnit = "Piastre", FractionalUnitAmount = 100 },
				new Currency { Name = "Lesotho loti", ISOCode = "LSL", Sign = "L", FractionalUnit = "Sente", FractionalUnitAmount = 100 },
				new Currency { Name = "South African rand", ISOCode = "ZAR", Sign = "R", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Liberian dollar", ISOCode = "LRD", Sign = "$", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Libyan dinar", ISOCode = "LYD", Sign = "ل.د", FractionalUnit = "Dirham", FractionalUnitAmount = 1000 },
				new Currency { Name = "Swiss franc", ISOCode = "CHF", Sign = "Fr", FractionalUnit = "Rappen", FractionalUnitAmount = 100 },
				new Currency { Name = "Lithuanian litas", ISOCode = "LTL", Sign = "Lt", FractionalUnit = "Centas", FractionalUnitAmount = 100 },
				new Currency { Name = "Macanese pataca", ISOCode = "MOP", Sign = "P", FractionalUnit = "Avo", FractionalUnitAmount = 100 },
				new Currency { Name = "Macedonian denar", ISOCode = "MKD", Sign = "ден", FractionalUnit = "Deni", FractionalUnitAmount = 100 },
				new Currency { Name = "Malagasy ariary", ISOCode = "MGA", Sign = "Ar", FractionalUnit = "Iraimbilanja", FractionalUnitAmount = 5 },
				new Currency { Name = "Malawian kwacha", ISOCode = "MWK", Sign = "MK", FractionalUnit = "Tambala", FractionalUnitAmount = 100 },
				new Currency { Name = "Malaysian ringgit", ISOCode = "MYR", Sign = "RM", FractionalUnit = "Sen", FractionalUnitAmount = 100 },
				new Currency { Name = "Maldivian rufiyaa", ISOCode = "MVR", Sign = "ރ", FractionalUnit = "Laari", FractionalUnitAmount = 100 },
				new Currency { Name = "Mauritanian ouguiya", ISOCode = "MRO", Sign = "UM", FractionalUnit = "Khoums", FractionalUnitAmount = 5 },
				new Currency { Name = "Mauritian rupee", ISOCode = "MUR", Sign = "₨", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Mexican peso", ISOCode = "MXN", Sign = "$", FractionalUnit = "Centavo", FractionalUnitAmount = 100 },
				new Currency { Name = "Micronesian dollar", ISOCode = null, Sign = "$", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Moldovan leu", ISOCode = "MDL", Sign = "L", FractionalUnit = "Ban", FractionalUnitAmount = 100 },
				new Currency { Name = "Mongolian tögrög", ISOCode = "MNT", Sign = "₮", FractionalUnit = "Möngö", FractionalUnitAmount = 100 },
				new Currency { Name = "Moroccan dirham", ISOCode = "MAD", Sign = "د.م.", FractionalUnit = "Centime", FractionalUnitAmount = 100 },
				new Currency { Name = "Mozambican metical", ISOCode = "MZN", Sign = "MT", FractionalUnit = "Centavo", FractionalUnitAmount = 100 },
				new Currency { Name = "Nagorno-Karabakh dram", ISOCode = null, Sign = "դր.", FractionalUnit = "Luma", FractionalUnitAmount = 100 },
				new Currency { Name = "Namibian dollar", ISOCode = "NAD", Sign = "$", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Nauruan dollar", ISOCode = null, Sign = "$", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Nepalese rupee", ISOCode = "NPR", Sign = "₨", FractionalUnit = "Paisa", FractionalUnitAmount = 100 },
				new Currency { Name = "Nicaraguan córdoba", ISOCode = "NIO", Sign = "C$", FractionalUnit = "Centavo", FractionalUnitAmount = 100 },
				new Currency { Name = "Nigerian naira", ISOCode = "NGN", Sign = "₦", FractionalUnit = "Kobo", FractionalUnitAmount = 100 },
				new Currency { Name = "Niue dollar", ISOCode = null, Sign = "$", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Turkish lira", ISOCode = "TRY", Sign = "₺", FractionalUnit = "Kuruş", FractionalUnitAmount = 100 },
				new Currency { Name = "Norwegian krone", ISOCode = "NOK", Sign = "kr", FractionalUnit = "Øre", FractionalUnitAmount = 100 },
				new Currency { Name = "Omani rial", ISOCode = "OMR", Sign = "ر.ع.", FractionalUnit = "Baisa", FractionalUnitAmount = 1000 },
				new Currency { Name = "Pakistani rupee", ISOCode = "PKR", Sign = "₨", FractionalUnit = "Paisa", FractionalUnitAmount = 100 },
				new Currency { Name = "Palauan dollar", ISOCode = null, Sign = "$", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Panamanian balboa", ISOCode = "PAB", Sign = "B/.", FractionalUnit = "Centésimo", FractionalUnitAmount = 100 },
				new Currency { Name = "Papua New Guinean kina", ISOCode = "PGK", Sign = "K", FractionalUnit = "Toea", FractionalUnitAmount = 100 },
				new Currency { Name = "Paraguayan guaraní", ISOCode = "PYG", Sign = "₲", FractionalUnit = "Céntimo", FractionalUnitAmount = 100 },
				new Currency { Name = "Peruvian nuevo sol", ISOCode = "PEN", Sign = "S/.", FractionalUnit = "Céntimo", FractionalUnitAmount = 100 },
				new Currency { Name = "Philippine peso", ISOCode = "PHP", Sign = "₱", FractionalUnit = "Centavo", FractionalUnitAmount = 100 },
				new Currency { Name = "Pitcairn Islands dollar", ISOCode = null, Sign = "$", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Polish złoty", ISOCode = "PLN", Sign = "zł", FractionalUnit = "Grosz", FractionalUnitAmount = 100 },
				new Currency { Name = "Qatari riyal", ISOCode = "QAR", Sign = "ر.ق", FractionalUnit = "Dirham", FractionalUnitAmount = 100 },
				new Currency { Name = "Romanian leu", ISOCode = "RON", Sign = "lei", FractionalUnit = "Ban", FractionalUnitAmount = 100 },
				new Currency { Name = "Rwandan franc", ISOCode = "RWF", Sign = "Fr", FractionalUnit = "Centime", FractionalUnitAmount = 100 },
				new Currency { Name = "Sahrawi peseta", ISOCode = "EHP", Sign = "Ptas", FractionalUnit = "Centime", FractionalUnitAmount = 100 },
				new Currency { Name = "Samoan tālā", ISOCode = "WST", Sign = "T", FractionalUnit = "Sene", FractionalUnitAmount = 100 },
				new Currency { Name = "São Tomé and Príncipe dobra", ISOCode = "STD", Sign = "Db", FractionalUnit = "Cêntimo", FractionalUnitAmount = 100 },
				new Currency { Name = "Saudi riyal", ISOCode = "SAR", Sign = "ر.س", FractionalUnit = "Halala", FractionalUnitAmount = 100 },
				new Currency { Name = "Serbian dinar", ISOCode = "RSD", Sign = "дин.", FractionalUnit = "Para", FractionalUnitAmount = 100 },
				new Currency { Name = "Seychellois rupee", ISOCode = "SCR", Sign = "₨", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Sierra Leonean leone", ISOCode = "SLL", Sign = "Le", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Solomon Islands dollar", ISOCode = "SBD", Sign = "$", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Somali shilling", ISOCode = "SOS", Sign = "Sh", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Somaliland shilling", ISOCode = "SLS", Sign = "Sh", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "South Georgia and the South Sandwich Islands pound", ISOCode = null, Sign = "£", FractionalUnit = "Penny", FractionalUnitAmount = 100 },
				new Currency { Name = "South Sudanese pound", ISOCode = "SSP", Sign = "£", FractionalUnit = "Piastre", FractionalUnitAmount = 100 },
				new Currency { Name = "Sri Lankan rupee", ISOCode = "LKR", Sign = "රු", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Sudanese pound", ISOCode = "SDG", Sign = "£", FractionalUnit = "Piastre", FractionalUnitAmount = 100 },
				new Currency { Name = "Surinamese dollar", ISOCode = "SRD", Sign = "$", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Swazi lilangeni", ISOCode = "SZL", Sign = "L", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Swedish krona", ISOCode = "SEK", Sign = "kr", FractionalUnit = "Öre", FractionalUnitAmount = 100 },
				new Currency { Name = "Syrian pound", ISOCode = "SYP", Sign = "ل.س", FractionalUnit = "Piastre", FractionalUnitAmount = 100 },
				new Currency { Name = "New Taiwan dollar", ISOCode = "TWD", Sign = "$", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Tajikistani somoni", ISOCode = "TJS", Sign = "ЅМ", FractionalUnit = "Diram", FractionalUnitAmount = 100 },
				new Currency { Name = "Tanzanian shilling", ISOCode = "TZS", Sign = "Sh", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Thai baht", ISOCode = "THB", Sign = "฿", FractionalUnit = "Satang", FractionalUnitAmount = 100 },
				new Currency { Name = "Tongan paʻanga", ISOCode = "TOP", Sign = "T$", FractionalUnit = "Seniti", FractionalUnitAmount = 100 },
				new Currency { Name = "Transnistrian ruble", ISOCode = "PRB", Sign = "р.", FractionalUnit = "Kopek", FractionalUnitAmount = 100 },
				new Currency { Name = "Trinidad and Tobago dollar", ISOCode = "TTD", Sign = "$", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Tristan da Cunha pound", ISOCode = null, Sign = "£", FractionalUnit = "Penny", FractionalUnitAmount = 100 },
				new Currency { Name = "Tunisian dinar", ISOCode = "TND", Sign = "د.ت", FractionalUnit = "Millime", FractionalUnitAmount = 1000 },
				new Currency { Name = "Turkmenistan manat", ISOCode = "TMT", Sign = "m", FractionalUnit = "Tennesi", FractionalUnitAmount = 100 },
				new Currency { Name = "Tuvaluan dollar", ISOCode = null, Sign = "$", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Ugandan shilling", ISOCode = "UGX", Sign = "Sh", FractionalUnit = "Cent", FractionalUnitAmount = 100 },
				new Currency { Name = "Ukrainian hryvnia", ISOCode = "UAH", Sign = "₴", FractionalUnit = "Kopiyka", FractionalUnitAmount = 100 },
				new Currency { Name = "United Arab Emirates dirham", ISOCode = "AED", Sign = "د.إ", FractionalUnit = "Fils", FractionalUnitAmount = 100 },
				new Currency { Name = "Uruguayan peso", ISOCode = "UYU", Sign = "$", FractionalUnit = "Centésimo", FractionalUnitAmount = 100 },
				new Currency { Name = "Uzbekistani som", ISOCode = "UZS", Sign = "лв", FractionalUnit = "Tiyin", FractionalUnitAmount = 100 },
				new Currency { Name = "Vanuatu vatu", ISOCode = "VUV", Sign = "Vt", FractionalUnit = null, FractionalUnitAmount = null },
				new Currency { Name = "Venezuelan bolívar", ISOCode = "VEF", Sign = "Bs", FractionalUnit = "Céntimo", FractionalUnitAmount = 100 },
				new Currency { Name = "Vietnamese đồng", ISOCode = "VND", Sign = "₫", FractionalUnit = "Hào", FractionalUnitAmount = 10 },
				new Currency { Name = "Yemeni rial", ISOCode = "YER", Sign = "﷼", FractionalUnit = "Fils", FractionalUnitAmount = 100 },
				new Currency { Name = "Zambian kwacha", ISOCode = "ZMK", Sign = "ZK", FractionalUnit = "Ngwee", FractionalUnitAmount = 100 }
			};

			currencies.ForEach(c => context.Currencies.Add(c));
			context.SaveChanges();
		}

		#endregion
	}
}
