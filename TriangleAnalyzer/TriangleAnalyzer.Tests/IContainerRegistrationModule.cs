﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleAnalyzer.Tests
{
    public interface IContainerRegistrationModule<T>
    {
        void Register(T container);
    }
}
