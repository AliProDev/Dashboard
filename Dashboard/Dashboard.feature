Feature: Dashboard

@Dashboard
Scenario: launch application and check dashboard information
	Given launch the application
	And check all task information in frist row
	When check the total points chart
	| StartYear | StartMonth | StartDay | EndYear | EndMonth | EndDay |
	| 2019      | Nov        | 1        | 2019    | Nov      | 20     |
	Then check MK team grid information 
	| FullName         | JobTitle                     | Rating | Budget     |
	| Rudolf Consadine | Structural Analysis Engineer | 4      | 94,258.00  |
	| Christabel Bick  | Engineer III                 | 5      | 65,359.00  |
	| Bink Byk         | Software Engineer I          | 3      | 56,472.00} |
	| Cassey Fitchell  | Software Engineer III        | 2      | 91,253.00  |
	| Bruis Creavin    | Nuclear Power Engineer       | 1      | 5,798.00   |
	| Adrianne Peery   | Chief Design Engineer        | 2      | 56,575.00  |
	| Ailsun Esmead    | Software Test Engineer III   | 1      | 69,596.00  |
	| Tally Rizzi      | Civil Engineer               | 1      | 78,575.00  |