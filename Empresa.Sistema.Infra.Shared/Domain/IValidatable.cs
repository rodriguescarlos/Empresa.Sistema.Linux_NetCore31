using System;

namespace Empresa.Sistema.Infra.Shared.Domain
{
    /// <summary>
    /// IValidatable interface.
    /// </summary>
    public interface IValidatable
    {
        /// <summary>
        /// Gets a value indicating whether this instance is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        bool EValido { get; }

        /// <summary>
        /// Gets the validation errors.
        /// </summary>
        /// <value>
        /// The validation errors.
        /// </value>
        ValidationErrors ErrosValidacao { get; }
    }
}