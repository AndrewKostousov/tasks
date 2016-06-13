using System;

using Core.Json;

namespace JsonConversion
{
    internal class JsonProgram
    {
        private static void Main()
        {
            var json = Console.In.ReadToEnd();
            //var json = "{'version':'2','constants':{'KrW':1.0,'VXX':2091752689.0},'products':{'2147483647':{'name':'bYG','price':'(KrW)/((VXX)+(KrW))','count':1},'1':{'name':'nOGRk1G','price':'(-54.6768867199667)/((-94.4693193745191)*(VXX))','count':921570388},'0':{'name':'YWd1bGWmx','price':'(VXX)+((-68.9409560379297)+(KrW))','count':1},'220138762':{'name':'LM3Jxgw','price':'(50.7671681934815)*((KrW)/(VXX))','count':1},'721734828':{'name':'GYq5','price':'(8.40230719577629)+((KrW)/(77.0179618042977))','count':1330719542},'1502878597':{'name':'z2CNkal9','price':'(KrW)*((KrW)*(VXX))','count':587644778},'709982529':{'name':'tzouK6','price':'(-64.9490050808289)-((-17.1325461553096)+(VXX))','count':1},'1182592088':{'name':'JnHdt','price':'(KrW)+((44.1574272439617)*(-10.270919702142))','count':1182987983}}}";
            //var json = "{\"version\":\"2\",\"constants\":{\"p\":\"375\'570\'429,00\",\"BDT5b\":\"1\'895\'861\'230,00\",\"pk6rq0teL\":\"2\'147\'483\'647,00\",\"d801p5J6\":\"1\'994\'942\'430,00\",\"GuuguI\":\"0,00\"},\"products\":{\"0\":{\"name\":\"RQbl0WfVY\",\"price\":\"(-84,07)*(p)\",\"count\":881891749},\"1\":{\"name\":\"kDaf0Z\",\"price\":\"(12,16)+(p)\",\"count\":2147483647},\"304322859\":{\"name\":\"KcOi9dvy\",\"price\":\"(pk6rq0teL)/(-37,02)\",\"count\":1},\"1408114756\":{\"name\":\"v4N\",\"price\":\"(-85,77)/(37,94)\",\"count\":1},\"1889271802\":{\"name\":\"wtXpL\",\"price\":\"(13,83)*(58,03)\",\"count\":0},\"687275581\":{\"name\":\"bp\",\"price\":\"(-92,39)-(d801p5J6)\",\"count\":0},\"1732466776\":{\"name\":\"IohrwvzQ\",\"price\":\"(d801p5J6)+(41,30)\",\"count\":2147483647},\"2147483647\":{\"name\":\"Abap\",\"price\":\"(-59,92)-(-66,58)\",\"count\":2147483647},\"517841970\":{\"name\":\"KD9S4\",\"price\":\"(58,49)/(p)\",\"count\":2147483647},\"1362982700\":{\"name\":\"9pH\",\"price\":\"(-54,43)/(-45,65)\",\"count\":1}}}";
            string serializeObject;
            try
            {
                serializeObject = WarehouseConverter.FixV3(json);
            }
            catch
            {
                serializeObject = WarehouseConverter.ConvertV2ToV3(json);
            }
            Console.Write(serializeObject);
            Console.ReadLine();
        }
    }
}