using EntityLibrary;
using DAOLibrary;
using ExceptionLibrary;
internal class MainModule
{
    private static void Main(string[] args)
    {
        try
        {
            CrimeAnalysisServiceImpl crimeService = new CrimeAnalysisServiceImpl();
            VictimDAO victimDAO = new VictimDAO();
            SuspectDAO suspectDAO = new SuspectDAO();

            bool exit = false; 

            while (!exit)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Manage Victims");
                Console.WriteLine("2. Manage Suspects");
                Console.WriteLine("3. Manage Incidents");
                Console.WriteLine("4. Exit");

                Console.WriteLine();
                Console.WriteLine();

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": // Manage Victims
                        ManageVictims(victimDAO);
                        break;

                    case "2": // Manage Suspects
                        ManageSuspects(suspectDAO);
                        break;

                    case "3": // Manage Incidents
                        ManageIncidents(crimeService);
                        break;

                    case "4": // Exit
                        Console.WriteLine("Exiting...");
                        exit = true; 
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred: " + ex.Message);
        }
    }

    private static void ManageSuspects(SuspectDAO suspectDAO)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Suspect Management:");
            Console.WriteLine("1. Add Suspect");
            Console.WriteLine("2. Get Suspect by ID");
            Console.WriteLine("3. Get All Suspects");
            Console.WriteLine("4. Back to Main Menu");

            Console.WriteLine();
            Console.WriteLine();

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Suspect newSuspect = new Suspect();
                    Console.WriteLine("Enter First Name:");
                    newSuspect.FirstName = Console.ReadLine();

                    Console.WriteLine("Enter Last Name:");
                    newSuspect.LastName = Console.ReadLine();

                    Console.WriteLine("Enter Date of Birth (yyyy-MM-dd):");
                    newSuspect.DateOfBirth = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Gender:");
                    newSuspect.Gender = Console.ReadLine();

                    Console.WriteLine("Enter Contact Information:");
                    newSuspect.ContactInformation = Console.ReadLine();

                    int newSuspectID = suspectDAO.AddSuspect(newSuspect);
                    bool isSuspectAdded = newSuspectID != 0;
                    Console.WriteLine(isSuspectAdded ? $"Suspect added successfully! SuspectID: {newSuspectID}" : "Failed to add suspect.");
                    Console.WriteLine();
                    Console.WriteLine();
                    break;

                case "2":
                    Console.WriteLine("Enter Suspect ID to retrieve:");
                    int suspectId = Convert.ToInt32(Console.ReadLine());
                    Suspect suspect = suspectDAO.GetSuspectById(suspectId);
                    if (suspect != null)
                    {
                        Console.WriteLine($"Suspect Found: {suspect.FirstName} {suspect.LastName}");
                    }
                    else
                    {
                        Console.WriteLine("Suspect not found.");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    break;

                case "3":
                    List<Suspect> suspects = suspectDAO.GetAllSuspects();
                    Console.WriteLine("All Suspects:");
                    foreach (var s in suspects)
                    {
                        Console.WriteLine($"{s.SuspectId}: {s.FirstName} {s.LastName}");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    break;

                case "4":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    Console.WriteLine();
                    Console.WriteLine();
                    break;
            }
        }
    }

    private static void ManageVictims(VictimDAO victimDAO)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Victim Management:");
            Console.WriteLine("1. Add Victim");
            Console.WriteLine("2. Get Victim by ID");
            Console.WriteLine("3. Get All Victims");
            Console.WriteLine("4. Back to Main Menu");

            Console.WriteLine();
            Console.WriteLine();

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Victim newVictim = new Victim();
                    Console.WriteLine("Enter First Name:");
                    newVictim.FirstName = Console.ReadLine();

                    Console.WriteLine("Enter Last Name:");
                    newVictim.LastName = Console.ReadLine();

                    Console.WriteLine("Enter Date of Birth (yyyy-MM-dd):");
                    newVictim.DateOfBirth = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Gender:");
                    newVictim.Gender = Console.ReadLine();

                    Console.WriteLine("Enter Contact Information:");
                    newVictim.ContactInformation = Console.ReadLine();

                    int newVictimID = victimDAO.AddVictim(newVictim);
                    bool isVictimAdded = newVictimID != 0;
                    Console.WriteLine(isVictimAdded ? $"Victim added successfully! VictimID: { newVictimID }" : "Failed to add victim.");

                    Console.WriteLine();
                    Console.WriteLine();
                    break;

                case "2":
                    Console.WriteLine("Enter Victim ID to retrieve:");
                    int victimId = Convert.ToInt32(Console.ReadLine());
                    Victim victim = victimDAO.GetVictimById(victimId);
                    if (victim != null)
                    {
                        Console.WriteLine($"Victim Found: {victim.FirstName} {victim.LastName}");
                    }
                    else
                    {
                        Console.WriteLine("Victim not found.");
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    break;

                case "3":
                    Console.WriteLine();
                    List<Victim> victims = victimDAO.GetAllVictims();
                    Console.WriteLine("All Victims:");
                    foreach (var v in victims)
                    {
                        Console.WriteLine($"{v.VictimId}: {v.FirstName} {v.LastName}");
                    }
                    break;

                    Console.WriteLine();
                    Console.WriteLine();

                case "4":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice, please try again.");

                    Console.WriteLine();
                    Console.WriteLine();
                    break;
            }
        }
    }

    private static void ManageIncidents(CrimeAnalysisServiceImpl crimeService)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("1. Create Incident");
            Console.WriteLine("2. Update Incident Status");
            Console.WriteLine("3. Get Incidents in Date Range");
            Console.WriteLine("4. Search Incidents by Type");
            Console.WriteLine("5. Generate Incident Report");
            Console.WriteLine("6. Create Case");
            Console.WriteLine("7. Get Case Details");
            Console.WriteLine("8. Update Case Details");
            Console.WriteLine("9. Get All Cases");
            Console.WriteLine("10. Back to Main Menu");

            Console.WriteLine();
            Console.WriteLine();

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Incident newIncident = new Incident();

                    Console.WriteLine("Enter Incident Type:");
                    newIncident.IncidentType = Console.ReadLine();

                    Console.WriteLine("Enter Incident Date (yyyy-MM-dd):");
                    newIncident.IncidentDate = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Location:");
                    newIncident.Location = Console.ReadLine();

                    Console.WriteLine("Enter Description:");
                    newIncident.Description = Console.ReadLine();

                    Console.WriteLine("Enter Status:");
                    newIncident.Status = Console.ReadLine();

                    Console.WriteLine("Enter Victim ID:");
                    newIncident.VictimId = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter Suspect ID:");
                    newIncident.SuspectId = Convert.ToInt32(Console.ReadLine());

                    int createdIncidentID = crimeService.CreateIncident(newIncident);
                    bool isCreated = createdIncidentID != 0;
                    Console.WriteLine(isCreated ? $"Incident created successfully! IncidentID: {createdIncidentID}" : "Failed to create incident.");

                    Console.WriteLine();
                    Console.WriteLine();
                    break;

                case "2":
                    Console.WriteLine("Enter Incident ID:");
                    int incidentId = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter new status:");
                    string status = Console.ReadLine();

                    bool isUpdated = crimeService.UpdateIncidentStatus(status, incidentId);
                    Console.WriteLine(isUpdated ? "Incident status updated!" : "Failed to update status.");

                    Console.WriteLine();
                    Console.WriteLine();
                    break;

                case "3":
                    Console.WriteLine("Enter start date (yyyy-MM-dd):");
                    DateTime startDate = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("Enter end date (yyyy-MM-dd):");
                    DateTime endDate = DateTime.Parse(Console.ReadLine());

                    List<Incident> incidents = crimeService.GetIncidentsInDateRange(startDate, endDate);
                    Console.WriteLine($"Incidents found: {incidents.Count}");
                    foreach (var incident in incidents)
                    {
                        Console.WriteLine($"{incident.IncidentId} - {incident.IncidentType} - {incident.Status}");
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    break;

                case "4":
                    Console.WriteLine("Enter Incident Type to search:");
                    string incidentType = Console.ReadLine();

                    Incident searchIncident = new Incident { IncidentType = incidentType };
                    List<Incident> foundIncidents = crimeService.SearchIncidents(searchIncident);

                    foreach (var incident in foundIncidents)
                    {
                        Console.WriteLine($"{incident.IncidentId} - {incident.IncidentType} - {incident.Status}");
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    break;

                case "5":
                    Console.WriteLine("Enter Incident ID to generate report:");
                    int reportIncidentId = Convert.ToInt32(Console.ReadLine());

                    Incident incidentForReport = crimeService.GetIncidentById(reportIncidentId);
                    Report report = crimeService.GenerateIncidentReport(incidentForReport);
                    Console.WriteLine($"Report Generated:\n{report.ReportDetails}");

                    Console.WriteLine();
                    Console.WriteLine();
                    break;

                case "6":
                    Console.WriteLine("Enter case description:");
                    string caseDescription = Console.ReadLine();

                    List<int> caseIncidentIds = new List<int>();  
                    Console.WriteLine("How many incidents to associate with the case?");
                    int incidentCount = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < incidentCount; i++)
                    {
                        Console.WriteLine($"Enter Incident ID #{i + 1}:");
                        int caseIncidentId = Convert.ToInt32(Console.ReadLine());
                        caseIncidentIds.Add(caseIncidentId);  
                    }

                    Case newCase = crimeService.CreateCase(caseDescription, caseIncidentIds); 
                    Console.WriteLine(newCase != null ? $"Case created with ID: {newCase.CaseId}" : "Failed to create case.");

                    Console.WriteLine();
                    Console.WriteLine();
                    break;

                case "7":
                    Console.WriteLine("Enter Case ID to get details:");
                    int caseId = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        Case caseDetails = crimeService.GetCaseDetails(caseId);
                        Console.WriteLine($"Case ID: {caseDetails.CaseId}, Description: {caseDetails.CaseDescription}");
                    }
                    catch (IncidentNumberNotFoundException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    break;

                case "8":
                    Console.WriteLine("Enter Case ID to update:");
                    int updateCaseId = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter new case description:");
                    string newCaseDescription = Console.ReadLine();

                    Case caseToUpdate = new Case { CaseId = updateCaseId, CaseDescription = newCaseDescription };
                    bool isCaseUpdated = crimeService.UpdateCaseDetails(caseToUpdate);
                    Console.WriteLine(isCaseUpdated ? "Case updated successfully!" : "Failed to update case.");

                    Console.WriteLine();
                    Console.WriteLine();
                    break;

                case "9":
                    List<Case> cases = crimeService.GetAllCases();
                    foreach (var caseObj in cases)
                    {
                        Console.WriteLine($"Case ID: {caseObj.CaseId}, Description: {caseObj.CaseDescription}");
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    break;

                case "10":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice, please try again.");

                    Console.WriteLine();
                    Console.WriteLine();
                    break;
            }
        }
    }
}