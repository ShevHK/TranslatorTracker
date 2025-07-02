using trans.tracker.lb.Services;

var service = new PdfManager();
var path = "./TestData/Course2Roadmap.pdf";
var res = service.GetSymbolsCount(path);
Console.WriteLine(res);