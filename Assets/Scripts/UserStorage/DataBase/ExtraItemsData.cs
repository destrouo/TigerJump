using System;
using System.Collections.Generic;
using UnityEngine;

namespace UserStorage.DataBase
{
    public class ExtraItemsData : ItemsData
    {
        [SerializeField] private string BigTtigerPla1;
        [SerializeField] private string BigTtigerPla2;
        [SerializeField] private string BigTtigerPla3;
        [SerializeField] private string BigTtigerPla4;


        private string tiger1;
        private string tiger2;
        private string tiger3;
        private string tiger4;
        private string tiger5;
        private string tiger6;

        private List<string> mergedTigers;

        [NonSerialized] public List<string> BigTigers;

        private void Awake()
        {
            InitializeTigers();
            MergeTigers();
            ProcessMergedTigers();
        }

        private void InitializeTigers()
        {
            tiger1 = "1222223";
            tiger2 = "42224";
            tiger3 = "55";
            tiger4 = "722227";
            tiger5 = "62222";
            tiger6 = "82228";
        }

        private void MergeTigers()
        {
            mergedTigers = new List<string>
            {
                tiger1,
                tiger2,
                tiger3,
                tiger4,
                tiger5,
                tiger6
            };

            BigTigers = new List<string>
            {
                BigTtigerPla1,
                BigTtigerPla2,
                BigTtigerPla3,
                BigTtigerPla4
            };
        }

        private void ProcessMergedTigers()
        {
            foreach (var tiger in mergedTigers)
            {
                // Work with the merged tigers using different variable names
                var ferociousTiger = tiger.Length; // Example usage of ferociousTiger
//                var BengalTiger = tiger.Substring(0, 3); // Example usage of BengalTiger
                var stripedTiger = tiger.Contains("Random") ? "Found" : "Not Found"; // Example usage of stripedTiger

                Debug.Log(
                    $"Tiger: {tiger}, ferociousTiger: {ferociousTiger}, stripedTiger: {stripedTiger}");
            }
        }

        public string ConcatenateStrings(List<string> siberianTigerBigTigers)
        {
            var ll = new List<string>(siberianTigerBigTigers);

            return "no";
        }
    }
}