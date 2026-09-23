using BibleBooksNE.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleBooksNE.ViewAndController.Navigation
{
    public enum UriType
    {
        unknown,
        // drive letters
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        N,
        O,
        P,
        Q,
        R,
        S,
        T,
        U,
        V,
        W,
        X,
        Y,
        Z,
        // source types
        data,
        file,
        ftp,
        http,
        https,
        // program types
        bible,
        book,
        chapter,
        error,
        link,
        message,
        msg,
        next,
        previous,
        selected,
        verse
    }


}
