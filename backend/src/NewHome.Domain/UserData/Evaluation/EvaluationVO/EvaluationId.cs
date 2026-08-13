using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHome.Domain.UserData.Evaluation.EvaluationVO
{
    public record EvaluationId
    {

        public Guid Value { get; }

        public static EvaluationId NewEvaluationId() => new(Guid.NewGuid());

        public static EvaluationId Empty() => new(Guid.Empty);

        private EvaluationId(Guid value)
        {
            Value = value;
        }

        public static EvaluationId CreateFromDB(Guid id) => new(id);
    }
}
