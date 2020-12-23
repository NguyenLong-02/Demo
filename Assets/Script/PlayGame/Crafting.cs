using Assets.Script.Material_And_Food;
using Assets.Script.Store_Data;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Play_Game
{
    public class Crafting : MonoBehaviour
    {
        [Header("GameObject")]
        public Button Sword;
        public Button Axe;
        public Button Pickage;

        [Header("Set Lifetime")]
        public float wood_life_time;
        public float rock_life_time;
        public float animal_life_time;

        [Header("Mat required")]
        private int wood_required;
        private int rock_required;
        private int food_required;
        private int twig_required;
        private int small_stone_required;

        // Check is able to crafting items;
        private void Update()
        {
            // Axe
            if (Resousce.Instance.woods >= wood_required &&
                Resousce.Instance.small_stone >= small_stone_required &&
                Resousce.Instance.rocks >= rock_required)
            {
                Axe.interactable = true;
            }
            else Axe.interactable = false;

            // Sword
            if (Resousce.Instance.woods >= wood_required &&
                Resousce.Instance.foods >= food_required &&
                Resousce.Instance.rocks >= rock_required)
            {
                Sword.interactable = true;
            }
            else Sword.interactable = false;

            // Pickage
            if (Resousce.Instance.woods >= wood_required &&
                Resousce.Instance.twigs >= twig_required &&
                Resousce.Instance.rocks >= rock_required)
            {
                Pickage.interactable = true;
            }
            else Pickage.interactable = false;
        }

        #region Crafting
        public void CraftAxe()
        {
            wood_required = 30;
            small_stone_required = 20;
            rock_required = 50;
            if(Resousce.Instance.woods >= wood_required &&
                Resousce.Instance.small_stone >= small_stone_required &&
                Resousce.Instance.rocks >= rock_required)
            {
                var list_has_tree = FindObjectsOfType<ATree>();
                foreach(var tree in list_has_tree)
                {
                    tree.lifetime /= 1.05f;
                    tree.materials += 10;
                }
                Resousce.Instance.woods -= wood_required;
                Resousce.Instance.small_stone -= small_stone_required;
                Resousce.Instance.rocks -= rock_required;
            }
        }

        public void CraftSword()
        {
            wood_required = 30;
            food_required = 20;
            rock_required = 50;
            if (Resousce.Instance.woods >= wood_required &&
                Resousce.Instance.foods >= food_required &&
                Resousce.Instance.rocks >= rock_required)
            {
                var list_has_rock = FindObjectsOfType<Animal>();
                foreach (var animal in list_has_rock)
                {
                    animal.lifetime /= 1.05f;
                    animal.materials += 10;
                }
                Resousce.Instance.woods -= wood_required;
                Resousce.Instance.foods -= food_required;
                Resousce.Instance.rocks -= rock_required;
            }
        }

        public void CraftPickage()
        {
            wood_required = 30;
            twig_required = 20;
            rock_required = 50;
            if (Resousce.Instance.woods >= wood_required &&
                Resousce.Instance.twigs >= twig_required &&
                Resousce.Instance.rocks >= rock_required)
            {
                var list_has_animal = FindObjectsOfType<Rock>();
                foreach (var rock in list_has_animal)
                {
                    rock.lifetime /= 1.05f;
                    rock.materials += 10;
                }
                Resousce.Instance.woods -= wood_required;
                Resousce.Instance.twigs -= twig_required;
                Resousce.Instance.rocks -= rock_required;
            }
        }
        #endregion
    }
}
