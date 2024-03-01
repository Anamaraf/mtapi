/*
 * QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
 * Lean Algorithmic Trading Engine v2.0. Copyright 2014 QuantConnect Corporation.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace ECFramework.Interfaces
{
    /// <summary>
    /// Defines an event fired from within an algorithm instance.
    /// </summary>
    /// <typeparam name="T">The event type</typeparam>
    /// <param name="algorithm">The algorithm that fired the event</param>
    /// <param name="eventData">The event data</param>
    //public delegate void AlgorithmEvent<in T>(IAlgorithm algorithm, T eventData);

    /// <summary>
    /// Interface for QuantConnect algorithm implementations. All algorithms must implement these
    /// basic members to allow interaction with the Lean Backtesting Engine.
    /// </summary>
    public interface IAlgorithm //: ISecurityInitializerProvider, IAccountCurrencyProvider
    {
        
    }
}
