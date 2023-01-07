using UnityEngine;
using UnityEngine.Events;

namespace AdventureQuest.Shop
{

    public class SaleProposalRenderer : MonoBehaviour
    {
        [field: SerializeField]
        public UnityEvent<string> OnChangeValue { get; private set; }
        [field: SerializeField]
        public UnityEvent<string> OnChangeTitle { get; private set; }
        [field: SerializeField]
        public UnityEvent<string> OnChangeMessage { get; private set; }
        public void Render(SaleProposal proposal)
        {
            OnChangeTitle.Invoke(proposal.Title);
            OnChangeValue.Invoke(proposal.Value.ToString());
            OnChangeMessage.Invoke(proposal.Message);
        }
    }
}