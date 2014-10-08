﻿// 
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

using System.Collections.Generic;
using SharpNL.Analyzer;
using SharpNL.Text.Tree;

namespace SharpNL.Text {
    /// <summary>
    /// Represents a sentence.
    /// </summary>
    public class Sentence : ISentence {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sentence"/> class.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="document">The document.</param>
        public Sentence(int start, int end, Document document) : this(start, end, null, document) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sentence"/> class.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="tokens">The tokens.</param>
        /// <param name="document">The document.</param>
        public Sentence(int start, int end, List<Token> tokens, Document document) {
            Start = start;
            End = end;
            Tokens = tokens.AsReadOnly();
            Document = document;
        }

        #region + Chunks .

        /// <summary>
        /// Gets the sentence chunks.
        /// </summary>
        /// <value>The sentence chunks.</value>
        public IReadOnlyList<Chunk> Chunks { get; internal set; }
        IReadOnlyList<IChunk> ISentence.Chunks {
            get { return Chunks; }
        }

        #endregion

        #region . Document .
        /// <summary>
        /// Gets the document.
        /// </summary>
        /// <value>The document.</value>
        public Document Document { get; private set; }
        IDocument ISentence.Document {
            get { return Document; }
        }

        #endregion

        #region . End .
        /// <summary>
        /// Gets the sentence end position.
        /// </summary>
        /// <value>The sentence end position.</value>
        public int End { get; private set; }
        #endregion

        #region . Entities .
        /// <summary>
        /// Gets the sentence entities.
        /// </summary>
        /// <value>The sentence entities.</value>
        public IReadOnlyList<IEntity> Entities { get; internal set; }
        #endregion

        #region . Length .
        /// <summary>
        /// Gets the sentence length.
        /// </summary>
        /// <value>The sentence length.</value>
        public int Length {
            get { return End - Start; }
            
        }
        #endregion

        #region + SyntacticChunks .

        /// <summary>
        /// Gets the syntactic chunks.
        /// </summary>
        /// <value>The syntactic chunks.</value>
        public IReadOnlyList<SyntacticChunk> SyntacticChunks { get; internal set; }

        IReadOnlyList<ISyntacticChunk> ISentence.SyntacticChunks {
            get { return SyntacticChunks; }
        }

        #endregion

        #region . Start .

        /// <summary>
        /// Gets the sentence start position.
        /// </summary>
        /// <value>The sentence start position.</value>
        public int Start { get; private set; }

        #endregion

        #region . Text .

        private string text;

        /// <summary>
        /// Gets the sentence text.
        /// </summary>
        /// <value>The sentence text.</value>
        public string Text {
            get {
                if (text != null)
                    return text;

                return (text = Document.Text.Substring(Start, Length));
            }
        }

        #endregion

        #region + Tokens .

        /// <summary>
        /// Gets the sentence tokens.
        /// </summary>
        /// <value>The sentence tokens.</value>
        public IReadOnlyList<Token> Tokens { get; internal set; }

        IReadOnlyList<IToken> ISentence.Tokens {
            get { return Tokens; }
        }

        #endregion

        #region . TokensProbability .

        /// <summary>
        /// Gets the tokens probability.
        /// </summary>
        /// <value>The tokens probability.</value>
        public double TokensProbability { get; internal set; }

        #endregion

        #region . Tree .

        private TreeNode tree;

        /// <summary>
        /// Gets the tree.
        /// </summary>
        /// <value>The tree.</value>
        public TreeNode Tree {
            get {
                if (tree != null)
                    return tree;

                return (tree = TreeNode.CreateTree(this));
            }
        }

        #endregion

        #region . SubString .
        /// <summary>
        /// Retrieves a substring from the current <see cref="Sentence"/> object. 
        /// The substring starts at a specified index number, or character position, in the <see cref="Sentence"/> object and has a specified length.
        /// </summary>
        /// <param name="startIndex">The starting index number in the substring.</param>
        /// <param name="length">The number of characters in the substring.</param>
        /// <returns>A <see cref="string"/> object equivalent to the substring of the length specified in the length parameter, beginning at the starting index number in the current sentence object.</returns>
        /// <remarks>The startIndex parameter is zero-based.</remarks>
        public string Substring(int startIndex, int length) {
            return Text.Substring(startIndex, length);
        }
        #endregion

    }
}