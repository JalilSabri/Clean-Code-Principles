using CleanCodePrinciples.Presentation;
using CleanCodePrinciples.Presentation.Classes;

Console.WriteLine("\n ---------------------- Clean Code Principals ----------------------");

#region .:| Data is string type |:.

using (CleanCodeService<string> cleanCodeService = new CleanCodeService<string>(new CleanCodeRepository<string>()))
{
    cleanCodeService.Add("Hello");
    cleanCodeService.Update("BackEnd", "FrontEnd");
    cleanCodeService.Delete(s => s.Equals("C#"));
    string? strGetFirst = cleanCodeService.GetFirst(s => s == "BackEnd");
    IEnumerable<string>? lstGetAll= cleanCodeService.GetAll();
    IEnumerable<string>? lstGetList = cleanCodeService.GetList(s => s.CompareTo("is") == 1);
    IEnumerable<string>? lstOrdered = cleanCodeService.GetList(s => s.CompareTo("is") == 1, q => q.OrderBy(s => s));
    var getByAnanymouse = lstGetAll!.Where<string>(delegate (string str) { return str.Equals("Development"); });
    var tt = getByAnanymouse.FirstOrDefault(s => s.Length > 5);

    foreach (var str in lstGetAll ?? new List<string> { "List is empty" })
    {
        Console.WriteLine(str);
    }
}

Console.WriteLine("\n================= End Of String Type Data ==========================\n");

#endregion

#region .:| Data is Record Type |:.

using (CleanCodeService<CleanCodeRecordTemplate> cleanCodeService = new CleanCodeService<CleanCodeRecordTemplate>(new CleanCodeRepository<CleanCodeRecordTemplate>()))
{
    cleanCodeService.Add(new CleanCodeRecordTemplate(11, "Test"));
    cleanCodeService.Update(new CleanCodeRecordTemplate(22, "Traditional"), new CleanCodeRecordTemplate(22, "CQRS"));
    cleanCodeService.Delete(s => s.Equals(new CleanCodeRecordTemplate(33, "Onion")));

    CleanCodeRecordTemplate? getRecordByFields = cleanCodeService.GetFirst(s => s.CleanCodeId >= 22 && s.CleanCodeName.Equals("CQRS"));
    CleanCodeRecordTemplate? getFirstFilterByRecord = cleanCodeService.GetFirst(s => s == new CleanCodeRecordTemplate(66, "Clean"));
    IEnumerable<CleanCodeRecordTemplate>? getRecordsById = cleanCodeService.GetAll()!.Where<CleanCodeRecordTemplate>(delegate (CleanCodeRecordTemplate rec) { return rec.CleanCodeId == 66; });

    IEnumerable<CleanCodeRecordTemplate>? lstGetAll = cleanCodeService.GetAll();
    IEnumerable<CleanCodeRecordTemplate>? lstGetList = cleanCodeService.GetList(d => d.CleanCodeId == 12);
    IEnumerable<CleanCodeRecordTemplate>? lstOrdered = cleanCodeService.GetList(d => d.CleanCodeName.Equals(""), q => q.OrderBy(d => d.CleanCodeId));

    foreach (var rec in lstGetAll ?? new List<CleanCodeRecordTemplate> { new CleanCodeRecordTemplate() { CleanCodeId = 0, CleanCodeName="List is empty" } })
    {
        Console.WriteLine(rec);
    }
}

Console.WriteLine("\n================= End Of Record Type Data ==========================\n");

#endregion

