namespace Assets._scripts.backend.game
{
    public interface IObjective
    {
        /// <summary>
        /// Name of the objective
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// Text specifying objective instructions
        /// </summary>
        string ObjectiveText
        {
            get;
        }

        /// <summary>
        /// Method checking wether the objective is completed or not
        /// </summary>
        bool isObjectiveComplete
        {
            get;
            set;
        }

    }
}
