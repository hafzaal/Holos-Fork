﻿using System;
using System.Collections.Generic;
using H.Core.Emissions.Results;
using H.Core.Enumerations;
using H.Core.Models;
using H.Core.Models.LandManagement.Fields;
using H.Core.Providers.Animals;

namespace H.Core.Services.Animals
{
    public interface IManureService
    {
        void Initialize(Farm farm, List<AnimalComponentEmissionsResults> animalComponentEmissionsResults);
        ManureTank GetTank(AnimalType animalType, int year, Farm farm);
        List<AnimalType> GetValidManureTypes();
        List<AnimalType> GetManureCategoriesProducedOnFarm(Farm farm);
        double GetVolumeAvailableForExport(int year);
        double GetVolumeAvailableForExport(int year, Farm farm, AnimalType animalType);
        List<ManureApplicationTypes> GetValidManureApplicationTypes();
        List<ManureLocationSourceType> GetValidManureLocationSourceTypes();
        List<ManureStateType> GetValidManureStateTypes(Farm farm, ManureLocationSourceType locationSourceType, AnimalType animalType);
        void SetValidManureStateTypes(ManureItemBase manureItemBase, Farm farm);

        /// <summary>
        /// (kg)
        /// </summary>
        double GetTotalVolumeOfManureExported(int year, Farm farm);

        /// <summary>
        /// (kg)
        /// </summary>
        double GetTotalVolumeOfManureExported(int year, Farm farm, AnimalType animalType);
        int GetYearHighestVolumeRemaining(AnimalType animalType);
        DefaultManureCompositionData GetManureCompositionData(ManureItemBase manureItemBase, Farm farm);

        /// <summary>
        /// Returns total TAN created by all animals on farm in specified year
        /// 
        /// (kg)
        /// </summary>
        double GetTotalTANCreated(int year);

        /// <summary>
        /// (kg)
        /// </summary>
        double GetTotalTANCreated(int year, AnimalType animalType);

        /// <summary>
        /// (kg)
        /// </summary>
        double GetTotalNitrogenCreated(int year);

        

        /// <summary>
        /// (kg)
        /// </summary>
        double GetTotalVolumeCreated(int year);

        /// <summary>
        /// (kg)
        /// </summary>
        double GetTotalVolumeCreated(int year, AnimalType animalType);

        /// <summary>
        /// Equation 4.6.1-8
        /// Equation 4.6.2-17
        /// Equation 4.6.2-18
        ///
        /// (kg N)
        /// </summary>
        double GetTotalNitrogenFromExportedManure(int year, Farm farm);

        double GetTotalNitrogenFromExportedManure(int year, Farm farm, AnimalType animalType);
        double GetTotalNitrogenFromManureImports(int year, Farm farm, AnimalType animalType);

        /// <summary>
        /// Equation 4.6.2-13
        /// 
        /// Nitrogen sum of all manure applications made to all fields from manure produced on the farm (does not include imported manure)
        ///
        /// (kg N)
        /// </summary>
        double GetTotalNitrogenAppliedToAllFields(int year);

        /// <summary>
        /// Equation 4.6.2-14
        /// 
        /// Stored nitrogen available for application to land minus manure applied to fields or exported
        ///
        /// (kg N)
        /// </summary>
        double GetTotalNitrogenRemaining(int year, Farm farm);

        /// <summary>
        /// Equation 4.6.2-14
        /// 
        /// Stored nitrogen (by animal manure type) available for application to land minus manure applied to fields or exported
        ///
        /// (kg N)
        /// </summary>
        double GetTotalNitrogenRemaining(int year, Farm farm, AnimalType animalType);

        /// <summary>
        /// (kg)
        /// </summary>
        double GetTotalNitrogenCreated(int year, AnimalType animalType);

        List<AnimalType> GetManureTypesExported(Farm farm, int year);
        List<AnimalType> GetManureTypesImported(Farm farm, int year);
        double GetFractionOfTotalManureUsedFromLandApplication(CropViewItem viewItem, ManureApplicationViewItem manureApplicationViewItem);
        double GetAmountOfTanUsedDuringLandApplication(CropViewItem cropViewItem, ManureApplicationViewItem manureApplicationViewItem);
        double GetAmountOfTanUsedDuringLandApplications(CropViewItem cropViewItem);
        double GetAmountOfTanExported(ManureExportViewItem manureExportViewItem, int year);
        List<Tuple<double, AnimalType>> GetTANExportedForFarm(Farm farm, int year);
        List<int> GetYearsWithManureApplied(Farm farm);

        /// <summary>
        /// Returns the total amount of TAN used (by animal/manure type) from all field applications on the farm
        /// </summary>
        List<Tuple<double, AnimalType>> GetTotalTanAppliedToAllFields(int year, List<CropViewItem> viewItems);

        /// <summary>
        /// Returns the total amount of TAN used (by animal/manure type) from all field applications on the field
        /// </summary>
        List<Tuple<double, AnimalType>> GetTotalTanAppliedToField(int year, CropViewItem cropViewItem);

        double GetTotalTANExportedByAnimalType(
            AnimalType animalType,
            Farm farm,
            int year);

        /// <summary>
        /// Equation 4.1.3-16
        ///
        /// Total_C_storage
        ///  
        /// (kg C)
        /// </summary>
        double GetTotalCarbonCreated(int year);

        /// <summary>
        /// (kg C) 
        /// </summary>
        double GetTotalCarbonFromImportedManure(Farm farm, int year);

        /// <summary>
        /// Equation 4.7.1-3
        ///
        /// (kg C)
        /// </summary>
        double GetTotalCarbonRemainingForFarm(Farm farm, int year);

        /// <summary>
        /// Equation 4.7.1-4
        ///
        /// (kg C)
        /// </summary>
        double GetTotalCarbonRemainingForField(Farm farm, int year, CropViewItem viewItem);

        /// <summary>
        /// Equation 4.7.1-5
        /// </summary>
        double GetTotalCarbonFromExportedManure(int year, Farm farm);

        double GetTotalCarbonInputsFromLivestockManureApplications(Farm farm, int year);

        double GetTotalManureCarbonInputsForField(Farm farm, int year, CropViewItem viewItem);
    }
}