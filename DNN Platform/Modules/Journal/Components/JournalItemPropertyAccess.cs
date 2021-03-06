﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information

using DotNetNuke.Services.Journal;

namespace DotNetNuke.Modules.Journal.Components {
    public class JournalItemTokenReplace : Services.Tokens.BaseCustomTokenReplace {
        public JournalItemTokenReplace(JournalItem journalItem, JournalControl journalControl) {
            PropertySource["journalitem"] = journalItem;
            PropertySource["journalcontrol"] = journalControl;
            if (journalItem.ItemData != null) {
                PropertySource["journaldata"] = journalItem.ItemData;
            }
            if (journalItem.JournalAuthor != null) {
                PropertySource["journalauthor"] = journalItem.JournalAuthor;
                PropertySource["journalprofile"] = new ProfilePicPropertyAccess(journalItem.JournalAuthor.Id);
            }
             
        }
        public string ReplaceJournalItemTokens(string source) {
            return ReplaceTokens(source);
        }
    }
}
