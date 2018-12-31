Feature: Bushey Hospital Page

@Browser_Chrome
@Hosp
Scenario Outline:  Verify top menu links exists on page
Given I navigated to <page> <hospital>
When I count the number of links
	| Menu                         | Count | Find							        | TestCase |
	| Book an appointment          | 6     | a[href*=book-an-appointment]			| 0        |
	| Treatments                   | 34    | a[href*=treatments]					| 1        |
	| Consultants                  | 3     | a[href*=consultants]					| 2        |
	| Patient information          | 9     | a[href*=patient-information]			| 3        |
	| Find us                      | 3     | a[href*=find-us]						| 4        |
	| GP info					   | 2     | a[href*=gp-info]	                    | 5        |
	| Prices                       | 0     | a[href*=prices]					    | 6        |

Scenarios: 
| page     | hospital               |
| homepage | spire-bushey-hospital/ |