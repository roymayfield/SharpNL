// 
//  Copyright 2014 Gustavo J Knuppe (https://github.com/knuppe)
// 
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
// 
//       http://www.apache.org/licenses/LICENSE-2.0
// 
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// 
//   - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
//   - May you do good and not evil.                                         -
//   - May you find forgiveness for yourself and forgive others.             -
//   - May you share freely, never taking more than you give.                -
//   - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
//  
/*

Copyright (c) 2001, Dr Martin Porter
Copyright (c) 2002, Richard Boulton
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

    * Redistributions of source code must retain the above copyright notice,
    * this list of conditions and the following disclaimer.
    * Redistributions in binary form must reproduce the above copyright
    * notice, this list of conditions and the following disclaimer in the
    * documentation and/or other materials provided with the distribution.
    * Neither the name of the copyright holders nor the names of its contributors
    * may be used to endorse or promote products derived from this software
    * without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

*/

// This file was generated automatically by the Snowball to OpenNLP and
// ported to SharpNL

namespace SharpNL.Stemmer.Snowball {
    public class NorwegianStemmer : SnowballStemmer {

        private static NorwegianStemmer instance;

        /// <summary>
        /// Gets the <see cref="NorwegianStemmer"/> instance.
        /// </summary>
        /// <value>The <see cref="NorwegianStemmer"/> instance.</value>
        public static NorwegianStemmer Instance {
            get { return instance ?? (instance = new NorwegianStemmer()); }
        }

        private NorwegianStemmer() { }

        /// <summary>
        /// Reduces the given word into its stem.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <returns>The stemmed word.</returns>
        public override string Stem(string word) {
            Current = word.ToLowerInvariant();
            CanStem();
            return Current;
        }


        private static readonly Among[] a_0 = {
            new Among("a", -1, 1, null),
            new Among("e", -1, 1, null),
            new Among("ede", 1, 1, null),
            new Among("ande", 1, 1, null),
            new Among("ende", 1, 1, null),
            new Among("ane", 1, 1, null),
            new Among("ene", 1, 1, null),
            new Among("hetene", 6, 1, null),
            new Among("erte", 1, 3, null),
            new Among("en", -1, 1, null),
            new Among("heten", 9, 1, null),
            new Among("ar", -1, 1, null),
            new Among("er", -1, 1, null),
            new Among("heter", 12, 1, null),
            new Among("s", -1, 2, null),
            new Among("as", 14, 1, null),
            new Among("es", 14, 1, null),
            new Among("edes", 16, 1, null),
            new Among("endes", 16, 1, null),
            new Among("enes", 16, 1, null),
            new Among("hetenes", 19, 1, null),
            new Among("ens", 14, 1, null),
            new Among("hetens", 21, 1, null),
            new Among("ers", 14, 1, null),
            new Among("ets", 14, 1, null),
            new Among("et", -1, 1, null),
            new Among("het", 25, 1, null),
            new Among("ert", -1, 3, null),
            new Among("ast", -1, 1, null)
        };



        private static readonly Among[] a_1 = {
            new Among("dt", -1, -1, null),
            new Among("vt", -1, -1, null)
        };


        private static readonly Among[] a_2 = {
            new Among("leg", -1, 1, null),
            new Among("eleg", 0, 1, null),
            new Among("ig", -1, 1, null),
            new Among("eig", 2, 1, null),
            new Among("lig", 2, 1, null),
            new Among("elig", 4, 1, null),
            new Among("els", -1, 1, null),
            new Among("lov", -1, 1, null),
            new Among("elov", 7, 1, null),
            new Among("slov", 7, 1, null),
            new Among("hetslov", 9, 1, null)
        };

        private static readonly char[] g_v = {
            (char) 17, (char) 65, (char) 16, (char) 1, (char) 0, (char) 0, (char) 0,
            (char) 0, (char) 0, (char) 0, (char) 0, (char) 0, (char) 0, (char) 0,
            (char) 0, (char) 0, (char) 48, (char) 0, (char) 128
        };

        private static readonly char[] g_s_ending = {(char) 119, (char) 125, (char) 149, (char) 1};


        private int I_x;
        private int I_p1;


        private void copy_from(NorwegianStemmer other) {
            I_x = other.I_x;
            I_p1 = other.I_p1;
            base.copy_from(other);
        }


        private bool r_mark_regions() {
            bool subroot = false;
            int v_1;
            int v_2;
            // (, line 26
            I_p1 = limit;
            // test, line 30
            v_1 = cursor;
            // (, line 30
            // hop, line 30
            {
                int c = cursor + 3;
                if (0 > c || c > limit) {
                    return false;
                }
                cursor = c;
            }
            // setmark x, line 30
            I_x = cursor;
            cursor = v_1;
            // goto, line 31
            while (true) {
                v_2 = cursor;
                do {
                    if (!(in_grouping(g_v, 97, 248))) {
                        break;
                    }
                    cursor = v_2;
                    subroot = true;
                    if (subroot) break;
                } while (false);
                if (subroot) {
                    subroot = false;
                    break;
                }
                cursor = v_2;
                if (cursor >= limit) {
                    return false;
                }
                cursor++;
            }
            // gopast, line 31
            while (true) {
                do {
                    if (!(out_grouping(g_v, 97, 248))) {
                        break;
                    }
                    subroot = true;
                    if (subroot) break;
                } while (false);
                if (subroot) {
                    subroot = false;
                    break;
                }
                if (cursor >= limit) {
                    return false;
                }
                cursor++;
            }
            // setmark p1, line 31
            I_p1 = cursor;
            // try, line 32
            do {
                // (, line 32
                if (!(I_p1 < I_x)) {
                    break;
                }
                I_p1 = I_x;
            } while (false);
            return true;
        }


        private bool r_main_suffix() {
            bool subroot = false;
            int among_var;
            int v_1;
            int v_2;
            int v_3;
            // (, line 37
            // setlimit, line 38
            v_1 = limit - cursor;
            // tomark, line 38
            if (cursor < I_p1) {
                return false;
            }
            cursor = I_p1;
            v_2 = limit_backward;
            limit_backward = cursor;
            cursor = limit - v_1;
            // (, line 38
            // [, line 38
            ket = cursor;
            // substring, line 38
            among_var = find_among_b(a_0, 29);
            if (among_var == 0) {
                limit_backward = v_2;
                return false;
            }
            // ], line 38
            bra = cursor;
            limit_backward = v_2;
            switch (among_var) {
                case 0:
                    return false;
                case 1:
                    // (, line 44
                    // delete, line 44
                    slice_del();
                    break;
                case 2:
                    // (, line 46
                    // or, line 46
                    do {
                        v_3 = limit - cursor;
                        do {
                            if (!(in_grouping_b(g_s_ending, 98, 122))) {
                                break;
                            }
                            subroot = true;
                            if (subroot) break;
                        } while (false);
                        if (subroot) {
                            subroot = false;
                            break;
                        }
                        cursor = limit - v_3;
                        // (, line 46
                        // literal, line 46
                        if (!(eq_s_b(1, "k"))) {
                            return false;
                        }
                        if (!(out_grouping_b(g_v, 97, 248))) {
                            return false;
                        }
                    } while (false);
                    // delete, line 46
                    slice_del();
                    break;
                case 3:
                    // (, line 48
                    // <-, line 48
                    slice_from("er");
                    break;
            }
            return true;
        }


        private bool r_consonant_pair() {
            int v_1;
            int v_2;
            int v_3;
            // (, line 52
            // test, line 53
            v_1 = limit - cursor;
            // (, line 53
            // setlimit, line 54
            v_2 = limit - cursor;
            // tomark, line 54
            if (cursor < I_p1) {
                return false;
            }
            cursor = I_p1;
            v_3 = limit_backward;
            limit_backward = cursor;
            cursor = limit - v_2;
            // (, line 54
            // [, line 54
            ket = cursor;
            // substring, line 54
            if (find_among_b(a_1, 2) == 0) {
                limit_backward = v_3;
                return false;
            }
            // ], line 54
            bra = cursor;
            limit_backward = v_3;
            cursor = limit - v_1;
            // next, line 59
            if (cursor <= limit_backward) {
                return false;
            }
            cursor--;
            // ], line 59
            bra = cursor;
            // delete, line 59
            slice_del();
            return true;
        }


        private bool r_other_suffix() {
            int among_var;
            int v_1;
            int v_2;
            // (, line 62
            // setlimit, line 63
            v_1 = limit - cursor;
            // tomark, line 63
            if (cursor < I_p1) {
                return false;
            }
            cursor = I_p1;
            v_2 = limit_backward;
            limit_backward = cursor;
            cursor = limit - v_1;
            // (, line 63
            // [, line 63
            ket = cursor;
            // substring, line 63
            among_var = find_among_b(a_2, 11);
            if (among_var == 0) {
                limit_backward = v_2;
                return false;
            }
            // ], line 63
            bra = cursor;
            limit_backward = v_2;
            switch (among_var) {
                case 0:
                    return false;
                case 1:
                    // (, line 67
                    // delete, line 67
                    slice_del();
                    break;
            }
            return true;
        }


        private bool CanStem() {
            int v_1;
            int v_2;
            int v_3;
            int v_4;
            // (, line 72
            // do, line 74
            v_1 = cursor;
            do {
                // call mark_regions, line 74
                if (!r_mark_regions()) {
                    break;
                }
            } while (false);
            cursor = v_1;
            // backwards, line 75
            limit_backward = cursor;
            cursor = limit;
            // (, line 75
            // do, line 76
            v_2 = limit - cursor;
            do {
                // call main_suffix, line 76
                if (!r_main_suffix()) {
                    break;
                }
            } while (false);
            cursor = limit - v_2;
            // do, line 77
            v_3 = limit - cursor;
            do {
                // call consonant_pair, line 77
                if (!r_consonant_pair()) {
                    break;
                }
            } while (false);
            cursor = limit - v_3;
            // do, line 78
            v_4 = limit - cursor;
            do {
                // call other_suffix, line 78
                if (!r_other_suffix()) {
                    break;
                }
            } while (false);
            cursor = limit - v_4;
            cursor = limit_backward;
            return true;
        }

    }
}