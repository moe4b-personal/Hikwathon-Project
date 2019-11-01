﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Narrative
{
	public class Page : MonoBehaviour
	{
        Book book;
        int index;
        public void Init(Book book)
        {
            this.book = book;

            index = book.Pages.IndexOf(this);
        }

        public bool Visible
        {
            get
            {
                return gameObject.activeSelf;
            }
            set
            {
                gameObject.SetActive(value);
            }
        }

		public void Begin()
        {
            transform.localPosition = Vector3.zero;
            transform.localEulerAngles = Vector3.zero;

            gameObject.SetActive(true);

            End();
        }

        public event Action OnEnd;
        protected void End()
        {
            OnEnd?.Invoke();
        }
	}
}