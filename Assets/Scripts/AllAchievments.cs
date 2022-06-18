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
                name:            "���� � ���������",
                description:     "�������� ���� ������ ���",
                roflDescription: "���� ��� �� ����� ���� ������",
                onRequirement:     Mod.onRelease);
/*            GameManager.singleton.Achievments["credit_first"] = new Achievment(
                id:              "credit_first",
                name:            "�������",
                description:     "��������� ���������� �������",
                roflDescription: "���� ������ � �����, �������� ����������",
                requirement:     Mod.onModRelease);*/
        }
    }
}

