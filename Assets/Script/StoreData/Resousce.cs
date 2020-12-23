using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Assets.Script.Material_And_Food;

namespace Assets.Script.Store_Data
{

    public class Resousce : MonoBehaviour
    {
        public static Resousce Instance;

        [Header("Queue of Material")]
        public List<ATree> list_trees = new List<ATree>();
        public List<Rock> list_rocks = new List<Rock>();
        public List<Animal> list_animals = new List<Animal>();

        [Header("Resousce")]
        public int foods;
        public int woods;
        public int rocks;
        public int twigs;
        public int small_stone;

        [Header("Material Text UI")]
        [SerializeField] private TextMeshProUGUI text_woods;
        [SerializeField] private TextMeshProUGUI text_rocks;
        [SerializeField] private TextMeshProUGUI text_foods;
        [SerializeField] private TextMeshProUGUI text_twigs;
        [SerializeField] private TextMeshProUGUI text_small_stone;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            var array_trees = FindObjectsOfType<ATree>();
            var array_rocks = FindObjectsOfType<Rock>();
            var array_animals = FindObjectsOfType<Animal>();

            foreach(ATree tree in array_trees)
            {
                list_trees.Add(tree);
            }
            foreach (Rock tree in array_rocks)
            {
                list_rocks.Add(tree);
            }

            foreach (Animal tree in array_animals)
            {
                list_animals.Add(tree);
            }
        }


        void Update()
        {
            text_woods.text = "" + woods;
            text_rocks.text = "" + rocks;
            text_foods.text = "" + foods;

            text_twigs.text = "" + twigs;
            text_small_stone.text = "" + small_stone;

        }
    }
}
