using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public static class AllAchievments
    {
        public static void setAllAchievments()
        {
            GameManager.singleton.Achievments["mod_create"] = new Achievment(
                id:              "mod_create",
                name:            "Вход в индустрию",
                description:     "Выпустил свой первый мод",
                roflDescription: "Мама мне не нужны твои деньги",
                onRequirement:     Mod.onRelease);
/*            GameManager.singleton.Achievments["credit_first"] = new Achievment(
                id:              "credit_first",
                name:            "Должник",
                description:     "Опробовал банковскую систему",
                roflDescription: "Взял деньги у людей, придется возвращать",
                requirement:     Mod.onModRelease);*/
        }
    }
}

