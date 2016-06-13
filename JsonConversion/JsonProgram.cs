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
            var serializeObject = WarehouseConverter.ConvertV2ToV3(json);
            Console.Write(serializeObject);
            Console.ReadLine();
        }
    }
}