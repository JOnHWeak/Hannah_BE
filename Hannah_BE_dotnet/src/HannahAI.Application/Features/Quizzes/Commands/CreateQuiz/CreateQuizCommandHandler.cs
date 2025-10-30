using AutoMapper;
using HannahAI.Application.Common.Interfaces;
using HannahAI.Application.Features.Quizzes.DTOs;
using HannahAI.Domain.Entities.Studio;
using MediatR;

namespace HannahAI.Application.Features.Quizzes.Commands.CreateQuiz;

public class CreateQuizCommandHandler : IRequestHandler<CreateQuizCommand, QuizDto>
{
    private readonly IRepository<Quiz> _quizRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateQuizCommandHandler(IRepository<Quiz> quizRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _quizRepository = quizRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<QuizDto> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
    {
        var quiz = new Quiz
        {
            Title = request.Title,
            Description = request.Description,
            TimeLimitMinutes = request.TimeLimitMinutes,
            SubjectId = request.SubjectId,
            Questions = request.Questions.Select(q => new QuizQuestion
            {
                Text = q.Text,
                Answers = q.Answers.Select(a => new QuizAnswer
                {
                    Text = a.Text,
                    IsCorrect = a.IsCorrect
                }).ToList()
            }).ToList()
        };

        await _quizRepository.AddAsync(quiz, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return _mapper.Map<QuizDto>(quiz);
    }
}
