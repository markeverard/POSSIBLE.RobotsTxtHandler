using System;
using System.Linq;
using EPiServer.Core.Transfer;
using EPiServer.Data;
using EPiServer.Data.Dynamic;
using EPiServer.Enterprise;
using EPiServer.Enterprise.Transfer;
using EPiServer.Framework;
using EPiServer.ServiceLocation;

namespace POSSIBLE.RobotsTxtHandler.Initialization
{
    /// <summary>
    /// Module to transfer the robots.txt content to mirrored servers when in a full staging/delivery configuration
    /// </summary>
    [InitializableModule, ModuleDependency(typeof(DataInitialization)), ModuleDependency(typeof(DynamicDataTransferHandler))]
    public class RobotsContentTransferInit : IInitializableModule
    {
        private Injected<IDataExportEvents> DataExportEvents { get; set; }
        public void Initialize(EPiServer.Framework.Initialization.InitializationEngine context)
        {
            DataExportEvents.Service.ContentExporting += this.DataExporter_Exporting;
        }

        public void Preload(string[] parameters)
        {
        }

        public void Uninitialize(EPiServer.Framework.Initialization.InitializationEngine context)
        {
            DataExportEvents.Service.ContentExporting -= this.DataExporter_Exporting;
        }

        private void DataExporter_Exporting(ITransferContext transferContext, ContentExportingEventArgs e)
        {
            var exporter = transferContext as ITransferHandlerContext;
            if (exporter != null && exporter.TransferType == TypeOfTransfer.MirroringExporting)
            {
                var ddsHandler = exporter.TransferHandlers.Single(p => p.GetType() == typeof(DynamicDataTransferHandler)) as DynamicDataTransferHandler;

                var store = typeof(RobotsTxtData).GetStore();
                var externalId = store.GetIdentity().ExternalId;
                var storeName = store.Name;

                if (ddsHandler != null)
                {
                    ddsHandler.AddToExport(externalId, storeName);
                }
            }
        }
    }
}
