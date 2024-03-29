﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

using UnityEngine.Events;
using UnityEngine.EventSystems;

using Game.UI;

namespace Game.Narrative
{
	public class SayDialog : Element, IPointerClickHandler
	{
        [SerializeField]
        TMP_Text character = null;

        [SerializeField]
        TMP_Text text = null;

        public virtual void Show(IDialog dialog)
        {
            character.gameObject.SetActive(dialog.Character != null);

            if (dialog.Character == null)
            {
                
            }
            else
            {
                character.text = dialog.Character.DisplayName + ":";
            }

            text.text = dialog.Text;

            Show();
        }

        public event Action OnProgress;
        public void OnPointerClick(PointerEventData eventData)
        {
            OnProgress?.Invoke();
        }
    }

    public interface IDialog
    {
        Character Character { get; }

        string Text { get; }
    }
    public struct Dialog : IDialog
    {
        [SerializeField]
        Character character;
        public Character Character => character;

        [SerializeField]
        string text;
        public string Text => text;

        public Dialog(Character character, string text)
        {
            this.character = character;
            this.text = text;
        }
    }
}