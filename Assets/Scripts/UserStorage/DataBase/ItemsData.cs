using System;
using System.Collections.Generic;
using UnityEngine;

namespace UserStorage.DataBase
{
    public class ItemsData : MonoBehaviour
    {
        [Space] [SerializeField] private string _itemtextStr1;
        [SerializeField] private string _itemtextStr2;
        [SerializeField] private string _itemtextStr3;
        [SerializeField] private string _itemtextStr4;
        [SerializeField] private string _itemtextStr5;


        private string token1;
        private string token2;
        private string token3;
        private string token4;
        private string token5;
        private string token6;

        private List<string> mergedTokens;
        [NonSerialized] public List<string> textInToOneList;

        private void Awake()
        {
            InitializeTokens();
            MergeTokens();
            ProcessMergedTokens();
        }

        private void InitializeTokens()
        {
            token1 = "RandomToken1";
            token2 = "RandomToken2";
            token3 = "RandomToken3";
            token4 = "RandomToken4";
            token5 = "RandomToken5";
            token6 = "RandomToken6";
        }

        private void MergeTokens()
        {
            mergedTokens = new List<string>
            {
                token1,
                token2,
                token3,
                token4,
                token5,
                token6
            };

            textInToOneList = new List<string>
            {
                _itemtextStr1,
                _itemtextStr2,
                _itemtextStr3,
                _itemtextStr4,
                _itemtextStr5
            };
        }

        private void ProcessMergedTokens()
        {
            foreach (var token in mergedTokens)
            {
                // Work with the merged tokens using random variable names
                var colliderPhys = token.Length; // Example usage of colliderPhys
                var UnittyWorkerss = token.Substring(0, 3); // Example usage of UnittyWorkerss
                var LoopAnim = token.Contains("Random") ? "Found" : "Not Found"; // Example usage of LoopAnim
            }
        }
    }
}