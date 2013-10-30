using System;
using System.Linq;
using EPiServer.Core.Transfer;
using EPiServer.Data;
using EPiServer.Data.Dynamic;
using EPiServer.Enterprise;
using EPiServer.Framework;

namespace POSSIBLE.RobotsTxtHandler.Initialization
{
    /// <summary>
    /// Module to transfer the robots.txt content to mirrored servers when in a full staging/delivery configuration
    /// </summary>
    [InitializableModule, ModuleDependency(typeof(DataInitialization)), ModuleDependency(typeof(DynamicDataTransferHandler))]
    public class RobotsContentTransferInit : IInitializableModule
    {
        public void Initialize(EPiServer.Framework.Initialization.InitializationEngine context)
        {
            DataExporter.Exporting += this.DataExporter_Exporting;
        }

        public void Preload(string[] parameters)
        {
        }

        public void Uninitialize(EPiServer.Framework.Initialization.InitializationEngine context)
        {
            DataExporter.Exporting -= this.DataExporter_Exporting;
        }

        private void DataExporter_Exporting(object sender, EventArgs e)
        {
            DataExporter exporter = sender as DataExporter;
            if (exporter.TransferType == TypeOfTransfer.MirroringExporting)
            {
                var ddsHandler = (sender as DataExporter).TransferHandlers.Single(p => p.GetType() == typeof(DynamicDataTransferHandler)) as DynamicDataTransferHandler;

                var store = typeof(RobotsTxtData).GetStore();
                var externalID = store.GetIdentity().ExternalId;
                var storeName = store.Name;
                ddsHandler.AddToExport(externalID, storeName);
            }
        }
    }
}
