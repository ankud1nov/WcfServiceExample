using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceExample
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ContractsInfoService" в коде и файле конфигурации.
    public class ContractsInfoService : IContractsInfoService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "true";
            }
            else
            {
                composite.StringValue += "false";
            }
            return composite;
        }

        public ContractInfo[] GetContractsInfo()
        {
            var ctx = new ContractsInfoContext();

            if (!ctx.ContractsInfo.Any())
                CreateTestContracts(ctx);

            var forReturn = ctx.ContractsInfo.ToArray();
            return forReturn;
        }

        public void CreateTestContracts(ContractsInfoContext context)
        {
            List<ContractInfo> contractInfoList = new List<ContractInfo>();
            for (int i = 0; i < 100; i++)
            {
                contractInfoList.Add(
                    new ContractInfo()
                    {
                        Id = i,
                        Number = (i).ToString(),
                        CreateDateTime = DateTime.Today.AddDays(-i),
                        LastEditDateTime = (i % 10 == 0) ? DateTime.Today : DateTime.Today.AddDays(-i)
                    });
            }
            context.ContractsInfo.AddRange(contractInfoList);
            context.SaveChanges();
        }
    }
}
