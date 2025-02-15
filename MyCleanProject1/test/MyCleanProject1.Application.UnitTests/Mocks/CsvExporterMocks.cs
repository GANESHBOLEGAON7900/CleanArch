﻿using CsvHelper;
using MyCleanProject1.Application.Contracts.Infrastructure;
using MyCleanProject1.Application.Features.Events.Queries.GetEventsExport;
using Moq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace MyCleanProject1.Application.UnitTests.Mocks
{
    public class CsvExporterMocks
    {
        public static Mock<ICsvExporter> GetCsvExporter()
        {
            var mockCsvExporter = new Mock<ICsvExporter>();
            mockCsvExporter.Setup(repo => repo.ExportEventsToCsv(It.IsAny<List<EventExportDto>>())).Returns(
                (List<EventExportDto> eventExportDtos) =>
                {
                    using var memoryStream = new MemoryStream();
                    using (var streamWriter = new StreamWriter(memoryStream))
                    {
                        using var csvWriter = new CsvWriter(streamWriter, new CultureInfo(""));
                        csvWriter.WriteRecords(eventExportDtos);
                    }

                    return memoryStream.ToArray();
                });
            return mockCsvExporter;
        }
    }
}
