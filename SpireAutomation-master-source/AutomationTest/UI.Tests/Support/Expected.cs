using System;
using System.Collections.Generic;

public class Expected
{
    public Expected()
    {

    }

    public string[] HospitalLinks()
    {
        //Store expected links


        String[] temp = new string[] { "Cheshire Hospital", "Fylde Coast Hospital", "Liverpool Hospital", "Manchester Hospital", "Murrayfield Hospital Wirral" };

        String[] exp1 = { "Regency Hospital Macclesfield", "Elland Hospital", "Hull and East Riding Hospital", "Leeds Hospital", "Methley Park Hospital" };
        String[] exp2 = { "Washington Hospital", "Cambridge Lea Hospital", "Hartswood Hospital", "Norwich Hospital", "Wellesley Hospital" };
        String[] exp3 = { "Leicester Hospital", "Little Aston Hospital", "Nottingham Hospital", "Parkway Hospital", "South Bank Hospital" };
        String[] exp4 = { "Alexandra Hospital", "Clare Park Hospital", "Dunedin Hospital", "Gatwick Park Hospital", "Portsmouth Hospital" };
        String[] exp5 = { "Southampton Hospital", "Sussex Hospital", "Tunbridge Wells Hospital", "Montefiore Hospital", "Bristol Hospital" };
        String[] exp6 = { "Spire Oncology Centre South West", "Edinburgh Hospitals, Murrayfield and Shawfair Park", "Cardiff Hospital", "Yale Hospital" };
        String[] exp7 = { "Abergele Consulting Rooms", "Bushey Hospital", "Harpenden Hospital", "London East Hospital", "St Anthony's Hospital", "Thames Valley Hospital" };

        //Sorts out issue with comma delimeter affecting count
        object[] toadd = new object[] { exp1, exp2, exp3, exp4, exp5, exp6, exp7 };

        temp = Add(temp, toadd);
        string[] expected = temp;


        return expected;

    }



    public string[] TreatmentLinks()
    { 
        //Store expected links
       

        String[] temp = new string[] { "Allergy and infectious diseases", "Blood tests", "Bones and joints", "Bowel treatments", "Breast screening and surgery" };
        String[] exp1 = { "Cancer investigations and treatments", "Cosmetic surgery", "Cyst removal", "Dental surgery", "Ear, nose and throat", "Eye surgery and treatments" };
        String[] exp2 = { "Family planning", "Foreign visa medical exams", "Gastroenterology", "General medicine", "General surgery", "Haematology", "Hand surgery", "Heart treatments" };
        String[] exp3 = { "Kidney treatments", "Men's health", "Neurosurgery and neurology", "Paediatrics", "Pain management", "Perform rehabilitation", "Perform sports services" };
        String[] exp4 = { "Physiotherapy", "Podiatry", "Respiratory medicine", "Rheumatology", "Scans and investigations", "Skin treatments", "Spinal surgery and treatments" };
        String[] exp5 = { "Sports science", "Urology", "Vascular surgery", "Weight loss", "Women's health" };

        //Sorts out issue with comma delimeter affecting count
        object[] toadd = new object[] { exp1, exp2, exp3, exp4, exp5 };

        temp = Add(temp, toadd);
        string[] expected = temp;


       return expected;

    }


    public string[] BusheyExpBookanAppointment()
    {
        //Store expected links


        String[] temp = new string[] { "Paying for yourself", "Private health insurance", "NHS patients" };
        String[] exp1 = { "International", "Medical loans", "inSpire" };


        //Sorts out issue with comma delimeter affecting count
        object[] toadd = new object[] { exp1 };
        temp = Add(temp, toadd);
        string[] expected = temp;


        return expected;

    }


    public string[] BushyExpTreatmentLinks()
    {
        //Store expected links


        String[] temp = new string[] { "Blood tests", "Bones and joints (Orthopaedics)", "Bowel treatments", "Breast screening and surgery" };
        String[] exp1 = { "Cancer investigations and treatments", "Cosmetic surgery", "Cyst removal", "Dental surgery and treatments"  };
        String[] exp2 = { "Ear, nose and throat (ENT) treatments", "Endocrinology", "Eye surgery and treatments", "Gastroenterology" };
        String[] exp3 = { "General surgery", "Hand surgery", "Heart treatments", "Kidney treatments", "Men's health", "Neurophysiology and neuro-otology" };
        String[] exp4 = { "Perform Physiotherapy", "Physiotherapy", "Respiratory medicine", "Scans and investigations", "Skin treatments", "Weight loss" };
        String[] exp5 = { "Women's health", "Podiatry", "Urological Care", "Elstree Cancer Centre", "One stop back clinic", "Private GP services" };
        String[] exp6 = { "Spire Bushey Diagnostic Centre", "Stroke Prevention Centre", "The Prostate Practice", "Triple assessment breast clinic" };

        //Sorts out issue with comma delimeter affecting count
        object[] toadd = new object[] { exp1, exp2, exp3, exp4, exp5, exp6 };

        temp = Add(temp, toadd);
        string[] expected = temp;


        return expected;

    }



    public string[] BusheyExpConsultantsLinks()
    {
        //Store expected links


        String[] temp = new string[] { "Overview" };
        String[] exp1 = { "Profiles", "CMA compliance" };


        //Sorts out issue with comma delimeter affecting count
        object[] toadd = new object[] { exp1 };
        temp = Add(temp, toadd);
        string[] expected = temp;


        return expected;

    }

    public string[] BusheyExpPatientInformation()
    {
        //Store expected links


        String[] temp = new string[] { "Your care", "Our facilities", "Our healthcare standards", "Visitors" };
        String[] exp1 = { "Why Spire?", "Compassion in practice", "Testimonials", "News and events", "Facebook Competition page" };


        //Sorts out issue with comma delimeter affecting count
        object[] toadd = new object[] { exp1 };
        temp = Add(temp, toadd);
        string[] expected = temp;


        return expected;

    }

    public string[] BusheyExpFindUs()
    {
        //Store expected links


        String[] temp = new string[] { "Locations", "Spire Bushey Diagnostic Centre"  };
        String[] exp1 = { "Elstree Cancer Centre" };


        //Sorts out issue with comma delimeter affecting count
        object[] toadd = new object[] { exp1 };
        temp = Add(temp, toadd);
        string[] expected = temp;


        return expected;

    }

    public string[] BusheyExpGpInfoResources()
    {
        //Store expected links


        String[] temp = new string[] { "GP education events"};
        String[] exp1 = { "Lunch and Learn" };


        //Sorts out issue with comma delimeter affecting count
        object[] toadd = new object[] { exp1 };
        temp = Add(temp, toadd);
        string[] expected = temp;


        return expected;

    }



    //String builder store expected string values into array
    private string[] Add(string[] ogarr, object[] toadd)
    {

        var results = new List<string>();
        results.AddRange(ogarr);

        for (int i = 0; i < toadd.Length; i++)
        {
            if (toadd[i].GetType() == typeof(string[]))
                results.AddRange((string[])toadd[i]);
            else
                results.Add((string)toadd[i]);
        }

        return results.ToArray();
    }

}
