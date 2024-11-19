﻿/*
	This file is part of Editor Extensions Redux /L Unleashed
		© 2018-2021 LisiasT : http://lisias.net <support@lisias.net>
		© 2016-2018 LinuxGyruGamer
		© 2013-2016 MachXXV

	Editor Extensions Redux /L is double licensed, as follows:
		* SKL 1.0 : https://ksp.lisias.net/SKL-1_0.txt
		* GPL 2.0 : https://www.gnu.org/licenses/gpl-2.0.txt

	And you are allowed to choose the License that better suit your needs.

	Editor Extensions Redux /L Unleashed is distributed in the hope that
	it will be useful, but WITHOUT ANY WARRANTY; without even the implied
	warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

	You should have received a copy of the SKL Standard License 1.0
	along with Editor Extensions Redux /L Unleashed.
	If not, see <https://ksp.lisias.net/SKL-1_0.txt>.

	You should have received a copy of the GNU General Public License 2.0
	along with Editor Extensions Redux /L Unleashed.
	If not, see <https://www.gnu.org/licenses/>.

*/
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using GUI = KSPe.UI.GUI;
using GUILayout = KSPe.UI.GUILayout;

namespace EditorExtensionsRedux.StripSymmetry
{
    // ReSharper disable once InconsistentNaming
    public class OSD
    {
        private class Message
        {
            public String Text;
            public Color Color;
            public float HideAt;
        }

        private readonly List<Message> _msgs = new List<Message>();

        private static GUIStyle CreateStyle(Color color)
        {
            var style = new GUIStyle
            {
                stretchWidth = true,
                alignment = TextAnchor.MiddleCenter,
                fontSize = 16,
                fontStyle = FontStyle.Bold,
                normal = { textColor = color }
            };
            return style;
        }

        private float CalcHeight()
        {
            var style = CreateStyle(Color.white);
            return _msgs.Aggregate(.0f, (a, m) => a + style.CalcSize(new GUIContent(m.Text)).y);
        }

        public void Update()
        {
            if (_msgs.Count == 0) return;
            _msgs.RemoveAll(m => Time.time >= m.HideAt);
            var h = CalcHeight();
            GUILayout.BeginArea(new Rect(0, Screen.height * 0.1f, Screen.width, h), CreateStyle(Color.white));
            _msgs.ForEach(m => GUILayout.Label(m.Text, CreateStyle(m.Color)));
            GUILayout.EndArea();
        }

        public void Error(String text)
        {
            AddMessage(text, XKCDColors.LightRed);
        }

        public void Warn(String text)
        {
            AddMessage(text, XKCDColors.Yellow);
        }

        public void Success(String text)
        {
            AddMessage(text, XKCDColors.Cerulean);
        }

        public void Info(String text)
        {
            AddMessage(text, XKCDColors.OffWhite);
        }

        public void AddMessage(String text, Color color, float shownFor = 3)
        {
            var msg = new Message { Text = text, Color = color, HideAt = Time.time + shownFor };
            _msgs.Add(msg);
        }
    }
}
