using AutoMapper;
using HannahAI.Application.Common.Interfaces;
using HannahAI.Application.Features.Quizzes.DTOs;
using HannahAI.Domain.Entities.Studio;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HannahAI.Application.Features.Quizzes.Commands.SubmitQuizAttempt;

public class SubmitQuizAttemptCommandHandler : IRequestHandler<SubmitQuizAttemptCommand, QuizAttemptDto>
{
    private readonly IRepository<Quiz> _quizRepository;
    private readonly IRepository<QuizAttempt> _attemptRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SubmitQuizAttemptCommandHandler(IRepository<Quiz> quizRepository, IRepository<QuizAttempt> attemptRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _quizRepository = quizRepository;
        _attemptRepository = attemptRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<QuizAttemptDto> Handle(SubmitQuizAttemptCommand request, CancellationToken cancellationToken)
    {
        // In a real app, you would need to load the quiz with questions and answers.
        // This requires the repository to support Include() or similar functionality.
        var quiz = await _quizRepository.GetByIdAsync(request.QuizId, cancellationToken);
        if (quiz == null)
        {
            throw new ValidationException("Quiz not found.");
        }

        // This is a simplified scoring logic. A real implementation would be more robust.
        int score = 0;
        // foreach (var submittedAnswer in request.Answers)
        // {
        //     var question = quiz.Questions.FirstOrDefault(q => q.Id == submittedAnswer.QuestionId);
        //     if (question != null)
        //     {
        //         var correctAnswer = question.Answers.FirstOrDefault(a => a.IsCorrect);
        //         if (correctAnswer != null && correctAnswer.Id == submittedAnswer.AnswerId)
        //         {
        //             score++;
        //         }
        //     }
        // }

        var attempt = new QuizAttempt
        {
            UserId = request.UserId,
            QuizId = request.QuizId,
            Score = score,
            StartedAt = DateTime.UtcNow, // This should be set when the attempt starts
            CompletedAt = DateTime.UtcNow
        };

        await _attemptRepository.AddAsync(attempt, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return _mapper.Map<QuizAttemptDto>(attempt);
    }
}
