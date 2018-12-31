Feature: Central Page

@Browser_Chrome
@Central
Scenario Outline:  Verify links
Given I navigated to <page> <area>
When I count the number of links
| Page         | Menu                | Count | Find                         | TestCase | Click |
| home         | Locations           | 1     | a[href*=locations]           | skip     | false |
| home         | Treatments          | 34    | a[href*=treatments]          | 17       | false |
| home         | Consultants         | 2     | a[href*=consultants ]        | skip     | false |
| home         | Patient information | 8     | a[href*=patient-information] | skip     | false |
| home         | How to book         | 7     | a[href*=how-to-book]         | skip     | false |
| ourlocations | Our locations       | 40    | a[href*=spirehealth]         | 16       | true  |
| Jobs         | Recruitment         | 1     | a[href*=recruitment]         | skip     | false |
| Jobs         | Why work at Spire?  | 1     | a[href*=why-work-at-spire]   | skip     | false |
| Jobs         | Roles we offer      | 1     | a[href*=roles-we-offer]      | skip     | false |
| Jobs         | Profiles            | 1     | a[href*=profiles]            | skip     | false |

Scenarios:  
| page          | area     |
| home          | 17       | 
