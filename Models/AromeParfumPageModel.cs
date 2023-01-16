using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Roba_Andrei_Proiect.Data;


namespace Roba_Andrei_Proiect.Models
{
    public class AromeParfumPageModel : PageModel
    {
        public List<AtributAromaData> AtributAromaDataList;
        public void PopulateAtributAromaData(Roba_Andrei_ProiectContext context, Parfum parfum)
        {
            var allArome = context.Aroma;
            var parfumArome = new HashSet<int>(
            parfum.AromeParfum.Select(c => c.ParfumID));
            AtributAromaDataList = new List<AtributAromaData>();
            foreach (var cat in allArome)
            {
                AtributAromaDataList.Add(new AtributAromaData
                {
                    AromaID = cat.ID,
                    Nume = cat.NumeAroma,
                    Atribut = parfumArome.Contains(cat.ID)
                });
            }
        }
        public void UpdateAromeParfum(Roba_Andrei_ProiectContext context,
        string[] selectedArome, Parfum parfumToUpdate)
        {
            if (selectedArome == null)
            {
                parfumToUpdate.AromeParfum = new List<AromaParfum>();
                return;
            }
            var selectedAromeHS = new HashSet<string>(selectedArome);
            var parfumArome = new HashSet<int>
            (parfumToUpdate.AromeParfum.Select(c => c.Aroma.ID));
            foreach (var cat in context.Aroma)
            {
                if (selectedAromeHS.Contains(cat.ID.ToString()))
                {
                    if (!parfumArome.Contains(cat.ID))
                    {
                        parfumToUpdate.AromeParfum.Add(
                        new AromaParfum
                        {
                            ParfumID = parfumToUpdate.ID,
                            AromaID = cat.ID
                        });
                    }
                }
                else
                {
                    if (parfumArome.Contains(cat.ID))
                    {
                        AromaParfum courseToRemove
                        = parfumToUpdate
                        .AromeParfum
                        .SingleOrDefault(i => i.AromaID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}